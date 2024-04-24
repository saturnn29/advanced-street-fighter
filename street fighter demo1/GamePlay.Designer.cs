namespace street_fighter_demo1
{
    partial class GamePlay
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePlay));
            GameTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            player1health = new Label();
            player2health = new Label();
            SuspendLayout();
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 0;
            // 
            // player1health
            // 
            player1health.AutoSize = true;
            player1health.BackColor = Color.Transparent;
            player1health.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            player1health.ForeColor = Color.White;
            player1health.Location = new Point(35, 84);
            player1health.Name = "player1health";
            player1health.Size = new Size(70, 28);
            player1health.TabIndex = 0;
            player1health.Text = "label1";
            // 
            // player2health
            // 
            player2health.AutoSize = true;
            player2health.BackColor = Color.Transparent;
            player2health.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            player2health.ForeColor = Color.White;
            player2health.Location = new Point(1027, 84);
            player2health.Name = "player2health";
            player2health.Size = new Size(70, 28);
            player2health.TabIndex = 1;
            player2health.Text = "label2";
            // 
            // GamePlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1280, 465);
            Controls.Add(player2health);
            Controls.Add(player1health);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GamePlay";
            Text = "Game Play";
            Paint += FormPaintEvent;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label player1health;
        private Label player2health;
    }
}