using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Pkcs;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace street_fighter_demo1
{
    public partial class GamePlay : Form
    {
        private PlayerOne player1;
        private PlayerTwo player2;
        private bool gameOverMessage = false;

        // Constructor for the GamePlay
        public GamePlay()
        {
            InitializeComponent();
            // Set various control styles for optimized rendering
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            // Initialize player instances with initial properties
            player1 = new PlayerOne("ryu", "extreme fighter", 10, 300, 20);
            player2 = new PlayerTwo("deejay", "ultimate fighter", 1199, 300, 20);
            // Display initial player health on the form
            player1health.Text = "Player 1 health: " + player1.Health;
            player2health.Text = "Player 2 health: " + player2.Health;
        }

        // Event handler for key down events
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Handle players movements
            player1.KeyMovementDown(e);
            player2.KeyMovementDown(e);
        }

        // Event handler for key up events
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Handle players attack
            player1.KeyAttackUp(e);
            player2.KeyAttackUp(e);
        }

        // Event handler for the form's paint event
        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            // Draw player 1 and set coordinate
            lock (player1.PlayerImage)
            {
                graphic.DrawImage(player1.PlayerImage, player1.X, player1.Y);
            }

            // Draw player 2 and set coordinate
            lock (player2.Player2Image)
            {
                graphic.DrawImage(player2.Player2Image, player2.X, player2.Y);
            }
        }

        // Event handler for the game timer tick event
        private void GameTimerEvent(object sender, EventArgs e)
        {
            this.Invalidate();
            //Move and update players positions
            player1.MovePlayer();
            player2.MovePlayer();
            player1.Update();
            player2.Update();
            CheckCollisions(); //Check for collision between players
            UpdateHealthLabels(); //Update health status for each player
        }

        // Event handler for the frame changed event
        private void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            this.Invalidate();
        }

        // Check for collisions between PlayerOne and PlayerTwo
        private void CheckCollisions()
        {
            // Check if PlayerOne and PlayerTwo are close enough and have punch action active
            if (ArePlayersClose(player1, player2) && player1.PlayingAction && player1.ActionStrength > 0 && player1.Num < 1)
            {
                player2.Health -= player1.ActionStrength; // Reduce PlayerTwo's health
                UpdateHealthLabels();
            }

            // Similar check for PlayerTwo punching PlayerOne
            if (ArePlayersClose(player1, player2) && player2.PlayingAction && player2.ActionStrength > 0 && player2.Num < 1)
            {
                player1.Health -= player2.ActionStrength; // Reduce PlayerOne's health
                UpdateHealthLabels();
            }
        }

        // Check if PlayerOne and PlayerTwo are close based on their X coordinates
        private bool ArePlayersClose(Player player1, Player player2)
        {
            // Define a distance threshold within which players are considered close
            int distanceThreshold = 75; 
            // Calculate the absolute difference in X coordinates between PlayerOne and PlayerTwo
            int xCoordinateDifference = Math.Abs(player1.X - player2.X);

            // Check if the absolute X coordinate difference is less than the defined threshold
            // If true, players are considered close; otherwise, they are not close enough
            return xCoordinateDifference < distanceThreshold;
        }

        // Update health labels and check for game over conditions
        private void UpdateHealthLabels()
        {
            player1health.Text = "Player 1 health: " + player1.Health;
            player2health.Text = "Player 2 health: " + player2.Health;

            // Check if any player's health drops below zero
            if (player1.Health <= 0 || player2.Health <= 0)
            {
                if (!gameOverMessage)
                {
                    // Show game over message 
                    MessageBox.Show("Game Over!");
                    gameOverMessage = true;
                }
            }
        }
    }
}