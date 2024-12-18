namespace VierGewinnt
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      // Zum Spiel Bildschirm
        {
            GameMenu gameScreen = new GameMenu();
            gameScreen.Show();
        }

        private void button2_Click(object sender, EventArgs e)      // Zum Optionen Menü
        {
            OptionsMenu optionsMenu = new OptionsMenu();
            optionsMenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)      // Beendet das Programm
        {
            this.Close();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
