using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.Player
{
    class Player
    {
        public int Arrows { get; set; }
        public int Coins { get; set; }
        public int Turns { get; set; }
        public bool WumpusBundle { get; set; }
        

        public Player()
        {
            Arrows = 3;
            Coins = 0;
            Turns = 0;
        }

        public int CalculateScore(bool WumpusBundle)
        {
            return 100 - Turns + Coins + (5 * Arrows) + (WumpusBundle ? 50 : 0); 
        }

        public void ShotArrow()
        {
            Arrows = Arrows--;
        }

        public void PurchaseArrows()
        {
            Arrows = Arrows + 2;
            Coins = Coins--;
        }

        public void PurchaseSecret()
        {
            Coins = Coins--;
        }

        public void Move()
        {
            Turns++;
            Coins++;
        }
    }
}
