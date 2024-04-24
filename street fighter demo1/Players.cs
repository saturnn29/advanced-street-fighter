using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace street_fighter_demo1
{
    public abstract class Player : StreetFighterGameObject
    {
        protected Image playerImage;
        protected Image player2Image;
        protected int actionStrength;
        protected int endFrame;
        protected int totalFrame;
        protected float num;
        protected int playerMoved;

        protected bool goLeft, goRight, goUp;
        protected bool directionPressed;
        protected bool playingAction;

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Health { get; set; }

        public bool PlayingAction
        {
            get { return playingAction; }
        }

        public int ActionStrength
        {
            get { return actionStrength; }
        }

        public float Num
        {
            get { return num; }
            set { num = value; }
        }

        public Image PlayerImage
        {
            get { return playerImage; }
            set { playerImage = value; }
        }

        public Image Player2Image
        {
            get { return player2Image; }
            set { player2Image = value; }
        }

        // Constructor for the Player class
        public Player(string name, string desc, int x, int y, int health) : base(name, desc)
        {
            X = x;
            Y = y;
            Health = health;
        }

        // Set up the animation for the player
        public virtual void SetupAnimation()
        {
            ImageAnimator.Animate(PlayerImage, OnFrameChangedHandler);
            FrameDimension dimensions = new FrameDimension(PlayerImage.FrameDimensionsList[0]);
            totalFrame = PlayerImage.GetFrameCount(dimensions);
            endFrame = totalFrame - 3;
        }

        // Event handler for the frame changed event
        public virtual void OnFrameChangedHandler(object? sender, EventArgs e)
        {
            ImageAnimator.UpdateFrames(PlayerImage);
        }

        // This method is responsible for advancing the animation frames and managing player state.
        public void Update()
        {
            // Check if the player is currently playing an action animation
            if (playingAction)
            {
                // Increment the animation frame by 0.5 for smoother animation as long as it's below the total frames
                if (num < totalFrame)
                {
                    num += 0.5f; // Control the animation speed
                }
            }

            // Check if the animation has reached the end (num == totalFrame)
            if (num == totalFrame)
            {
                // Reset the player to a default state and stop playing the action
                ResetPlayer();
            }
        }

        // Set up the player with a specific animation and strength
        public virtual void SetPlayer(string player, int strength)
        {
            PlayerImage = Image.FromFile(player);
            actionStrength = strength;
            SetupAnimation();
            playingAction = true;
        }

        // Handle key down event for PLayer 1 movement controls
        public virtual void KeyMovementDown(KeyEventArgs e)
        {
            // Common player controls
            if (e.KeyCode == Keys.Left && !directionPressed)
            {
                MovePlayerAnimation("left");
            }

            if (e.KeyCode == Keys.Right && !directionPressed)
            {
                MovePlayerAnimation("right");
            }

            if (e.KeyCode == Keys.Up && !directionPressed)
            {
                MovePlayerAnimation("up");
            }
        }


        // Handle key up event for Player 1 attack controls
        public virtual void KeyAttackUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                goLeft = false;
                goRight = false;
                goUp = false;
                directionPressed = false;
                ResetPlayer();
            }

            if (e.KeyCode == Keys.A && !playingAction && !goLeft && !goRight)
            {
                SetPlayerAction("punch1.gif", 2);
            }

            if (e.KeyCode == Keys.S && !playingAction && !goLeft && !goRight)
            {
                SetPlayerAction("punch2.gif", 5);
            }
        }

        // Move the player based on directional controls
        public void MovePlayer()
        {
            if (goLeft)
            {
                if (X < 1200)
                {
                    X -= 6;
                }

                if (X <= 1)
                {
                    X += 6;
                }
            }

            if (goRight)
            {
                if (X > 1)
                {
                    X += 6;
                }

                if (X >= 1200)
                {
                    X -= 6;
                }
            }
        }

        // Move the player with a specific animation based on direction
        public virtual void MovePlayerAnimation(string direction)
        {
            if (direction == "left")
            {
                goLeft = true;
                PlayerImage = Image.FromFile("backwards.gif");
            }

            if (direction == "right")
            {
                goRight = true;
                PlayerImage = Image.FromFile("forwards.gif");
            }

            SetupAnimation();
            directionPressed = true;
            playingAction = false;
        }

        // Reset the player to a standing position
        public virtual void ResetPlayer()
        {
            PlayerImage = Image.FromFile("standing.gif");
            num = 0;
            playingAction = false;
            SetupAnimation();
        }

        // Set the player to a specific action animation with a given strength
        public virtual void SetPlayerAction(string animation, int strength)
        {
            PlayerImage = Image.FromFile(animation);
            playingAction = true;
            actionStrength = strength;
            SetupAnimation();
        }
    }
}