using System;

namespace street_fighter_demo1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void GamePlay(object sender, EventArgs e)
        {
            GamePlay GameWindow = new GamePlay();
            GameWindow.Show();
        }

        private void Guide(object sender, EventArgs e)
        {
            Help GameWindow = new Help();

            GameWindow.Show();
        }
    }
}