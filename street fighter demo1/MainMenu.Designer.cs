namespace street_fighter_demo1
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            GameTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            // 
            // button1
            // 
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(35, 122);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 0;
            button1.Text = "Game Play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += GamePlay;
            // 
            // button3
            // 
            button3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(35, 220);
            button3.Name = "button3";
            button3.Size = new Size(200, 50);
            button3.TabIndex = 2;
            button3.Text = "How To Play";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Guide;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "MainMenu";
            Text = "104222060 - Street Fighter";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private Button button1;
        private Button button3;
    }
}