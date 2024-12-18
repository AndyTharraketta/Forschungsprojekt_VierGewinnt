namespace VierGewinnt
{
    partial class GameInstruction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameInstruction));
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(119, 371);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Zurück";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.GradientActiveCaption;
            textBox2.Location = new Point(12, 90);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(328, 275);
            textBox2.TabIndex = 3;
            textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HotTrack;
            textBox1.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Gold;
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(328, 61);
            textBox1.TabIndex = 4;
            textBox1.Text = "Anleitung";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // GameInstruction
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(352, 450);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Name = "GameInstruction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameInstruction";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}