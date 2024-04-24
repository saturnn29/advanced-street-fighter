using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace street_fighter_demo1
{
    // PlayerTwo class representing the second player in the game
    public class PlayerTwo : Player
    {
        public PlayerTwo(string name, string desc, int x, int y, int health) : base(name, desc, x, y, health)
        {
            this.X = x;
            this.Y = y;
            this.Health = health;
            SetPlayer("deejay-standing.gif", 20);
        }

        // Set up player 2 - Dee Jay
        public override void SetPlayer(string player, int strength)
        {
            Player2Image = Image.FromFile(player);
            actionStrength = strength;
            SetupAnimation();
            playingAction = true;
        }

        // Override from Player class
        public override void SetupAnimation()
        {
            ImageAnimator.Animate(Player2Image, OnFrameChangedHandler);
            FrameDimension dimensions = new FrameDimension(Player2Image.FrameDimensionsList[0]);
            totalFrame = Player2Image.GetFrameCount(dimensions);
            endFrame = totalFrame - 3;
        }

        // Override from Player class
        public override void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            ImageAnimator.UpdateFrames(Player2Image);
        }

        // Override from Player class
        public override void MovePlayerAnimation(string direction)
        {
            if (direction == "left")
            {
                goLeft = true;
                Player2Image = Image.FromFile("deejay-forward.gif");
            }

            if (direction == "right")
            {
                goRight = true;
                Player2Image = Image.FromFile("deejay-backward.gif");
            }

            SetupAnimation();
            directionPressed = true;
            playingAction = false;
        }

        // Override to handle key up event for Player 2 attack controls
        public override void KeyAttackUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L || e.KeyCode == Keys.J || e.KeyCode == Keys.I)
            {
                goLeft = false;
                goRight = false;
                goUp = false;
                directionPressed = false;
                ResetPlayer();
            }

            if (e.KeyCode == Keys.B && !playingAction && !goLeft && !goRight)
            {
                SetPlayerAction("deejay-kick.gif", 2);
            }

            if (e.KeyCode == Keys.N && !playingAction && !goLeft && !goRight)
            {
                SetPlayerAction("deejay-punch.gif", 5);
            }
        }

        // Override to handle player 2 movement control
        public override void KeyMovementDown(KeyEventArgs e)
        {
            // Player 1 controls
            if (e.KeyCode == Keys.J && !directionPressed)
            {
                MovePlayerAnimation("left");
            }

            if (e.KeyCode == Keys.L && !directionPressed)
            {
                MovePlayerAnimation("right");
            }

            if (e.KeyCode == Keys.I && !directionPressed)
            {
                MovePlayerAnimation("up");
            }
        }

        // Reset Dee Jay after each action
        public override void ResetPlayer()
        {
            Player2Image = Image.FromFile("deejay-standing.gif");
            num = 0;
            playingAction = false;
            SetupAnimation();
        }

        // Set Dee Jay to a specific action animation with a given strength
        public override void SetPlayerAction(string animation, int strength)
        {
            Player2Image = Image.FromFile(animation);
            playingAction = true;
            actionStrength = strength;
            SetupAnimation();
        }
    }
}
