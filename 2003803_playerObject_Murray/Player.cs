using System;
using System.Collections.Generic;
using System.Text;

namespace _2003803_playerObject_Murray
{
    class Player
    {
        public int Arrows { get; set; }
        public int Coins { get; set; }
        public int Turns { get; set; }
        public int WumpusBundle { get; set; }

        public Player()
        {
            Arrows = 3;
            Coins = 0;
            Turns = 0;
        }

        public int CalculateScore()
        {
           return 100 - Turns + Coins + (5 * Arrows); //+ wumpus points
        }

        public void ShootArrows()
        {
            Arrows = Arrows--;
        }

        public void PurchaceArrows()
        {
            Arrows = Arrows + 2;
            Coins = Coins--;
        }

        public void PurchaceSecrets()
        {
           Coins = Coins--;
        }

        public void Move()
        {
            Turns++;
        }
    }
}
