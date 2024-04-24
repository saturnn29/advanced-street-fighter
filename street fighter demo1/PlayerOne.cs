using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using street_fighter_demo1;

namespace street_fighter_demo1
{
    // PlayerOne class representing the first player in the game
    public class PlayerOne : Player
    {
        public PlayerOne(string name, string desc, int x, int y, int health) : base(name, desc, x, y, health)
        {
            X = x;
            Y = y;
            this.Health = health;
            SetPlayer("standing.gif", 20);
        }
    }
}
