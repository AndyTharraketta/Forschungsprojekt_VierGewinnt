using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VierGewinnt
{
    public partial class PlayGame : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Label[,] Feld = new Label[7, 6];            // Array für Spielfeld 
        bool red = true;                            // Boolean um festzustellen welcher Spieler an der Reihe ist (Rot/Gelb)
        int[] hoehe = { 5, 5, 5, 5, 5, 5, 5 };      // Array für die Höhe der Spalten
        int moves = 42;                             // Zähler für die Spielzüge
        public PlayGame()
        {
            InitializeComponent();
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 50, 50);          // Erstellen des Bereichs in dem die Spielsteine gesetzt werden sollen
            int index = 2;

            for (int X = 0; X < 7; X++)             // Schleife für das Erstellen des Spielfelds
            {
                for (int Y = 0; Y < 6; Y++)
                {
                    Feld[X, Y] = new System.Windows.Forms.Label();      
                    Feld[X, Y].BackColor = Color.White;                                 // Für die Hintergrundfarbe (Weiß)
                    Feld[X, Y].AutoSize = false;
                    Feld[X, Y].Location = new System.Drawing.Point(X * 50, Y * 50);     // Position der Labels
                    Feld[X, Y].Name = "label" + (index++);                              // Name der Labels
                    Feld[X, Y].Size = new System.Drawing.Size(50, 50);                  // Größe der Labels
                    Feld[X, Y].TabIndex = index;                                        // Tabulator-Index für die Labels
                    Feld[X, Y].Region = new Region(path);                               // Zur Erstellung eines runden Bereichs
                    Feld[X, Y].Text = "";                                               // Damit kein Text in den Labels ist
                    Feld[X, Y].AccessibleDescription = "";                              // Keine Beschreibung für Barrierefreiheit
                    Feld[X, Y].Click += new System.EventHandler(this.label1_Click);     // Ereignis-Handler für Klick (damit man die Buttons mit der Maus anklicken kann)
                    this.Controls.Add(Feld[X, Y]);                                      // Label wird zum Formular hinzugefügt
                }
            }
        }
        private bool inReihe(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)        // Methode prüft Reihe
        {

            if (Feld[x1, y1].AccessibleDescription == Feld[x2, y2].AccessibleDescription &&
                Feld[x2, y2].AccessibleDescription == Feld[x3, y3].AccessibleDescription &&
                Feld[x3, y3].AccessibleDescription == Feld[x4, y4].AccessibleDescription &&
                Feld[x1, y1].AccessibleDescription != "")
                return true;
            return false;
        }
        private bool Diagonale1()                                                                   // Methode prüft Diagonale von oben links nach unten rechts 
        {
            for (int x = 0; x < 4; x++)                                                             // Prüft Spalte von links nach rechhts         
            {
                for (int y = 5; y >= 3; y--)                                                        // Prüft Reihe von unten nach oben
                {
                    if (inReihe(x, y, x + 1, y - 1, x + 2, y - 2, x + 3, y - 3)) return true;
                }
            }
            return false;
        }
        private bool Diagonale2()                                                                   // Methode prüft Diagonale von unten links nach oben rechts 
        {
            for (int x = 0; x < 4; x++)                                                             // Prüft Spalte von links nach rechts
            {
                for (int y = 0; y <= 2; y++)                                                        // Prüft Reihe von oben nach unten
                {
                    if (inReihe(x, y, x + 1, y + 1, x + 2, y + 2, x + 3, y + 3)) return true;
                }
            }
            return false;
        }
        private bool gewonnen(int X, int Y)                                                         // Prüft ob aktueller Spieler gewonnen hat 
        {
            for (int i = 0; i < 4; i++)                                                             // Prüft vertikale Reihe
                if (inReihe(i, Y, i + 1, Y, i + 2, Y, i + 3, Y)) return true;
            for (int i = 0; i < 3; i++)                                                             // Prüft horizontale Reihe
                if (inReihe(X, i, X, i + 1, X, i + 2, X, i + 3)) return true;
            if (Diagonale1()) return true;                                                          // Prüft Diagonale (oben links nach rechts unten)
            if (Diagonale2()) return true;                                                          // Prüft Diagonale (unten links nach rechts oben)
            return false;
        }
        private void reset(string s)            // Methode zum Zurücksetzen des Spiels  
        {
            MessageBox.Show(s);                 // Anzeige wer gewonnen hat oder Unentschieden
            red = true;                         // Spieler auf Rot zurücksetzen
            for (int i = 0; i < 7; i++)         // Spalten zurücksetzen
                hoehe[i] = 5;
            foreach (Label L in Feld)
            {
                L.BackColor = Color.White;      // Alle Spielfelder zurücksetzen (Weiß)
                L.AccessibleDescription = "";   // Alle Spielfelder zurücksetzen
            }
            moves = 42;                         // Spielzüge zurücksetzen
        }
        private void label1_Click(object sender, EventArgs e)                               // Ereignis-Hanlder für Klicks auf die Labels
        {
            int X = (sender as Label).Location.X / 50;                                      // Bestimmen der Spalte (Position Labels)
            int Y = hoehe[X]--;                                                             // Bestimmen der Höhe ()!!!!!
            if (Y >= 0)                                                                     // Wenn Höhe gültig
            {
                Feld[X, Y].BackColor = (red ? Color.Red : Color.Yellow);                    // Setz Hintergrundfarbe des aktuellen Spielers ein
                Feld[X, Y].AccessibleDescription = (red ? "red" : "yellow");                // Setz Beschreibung des aktuellen Spielers ein
                moves--;                                                                    // Reduziert die Anzahl der Spielzüge
                if (gewonnen(X, Y)) reset((red ? "Rot" : "Gelb") + " hat gewonnen.");       // Prüft ob aktueller Spieler gewonen hat
                else if (moves <= 0) reset("Unentschieden");                                // Prüft ob kein Spieler gewonnen hat (Unentschieden)
                else red = red ? false : true;                                              // Spieler wechsel
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();                                                                   // Zurück zum vorherigen Menü
        }
    }

}

