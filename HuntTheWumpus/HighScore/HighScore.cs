using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.HighScore
{
    class HighScore
    {
        public string name { get; set; }
        public int score { get; set; }
        public string caveName { get; set; }
        public DateTime dateTime { get; set; }


        public Highscore(string n, int s, string cn, DateTime dt)
        {
            name = n;
            score = s;
            caveName = cn;
            dateTime = dt;
        }

    }
}
