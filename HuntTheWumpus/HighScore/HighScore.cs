using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.HighScore
{
    public class HighScore
    {
        public string name { get; set; }
        public int score { get; set; }
        public string caveName { get; set; }
        public DateTime dateTime { get; set; }


        public HighScore(string n, int s, string cn, DateTime dt)
        {
            name = n;
            score = s;
            caveName = cn;
            dateTime = dt;
        }

        public override bool Equals(object obj)
        {
            if (obj is HighScore hs)
            {
                return name == hs.name && score == hs.score && caveName == hs.caveName && dateTime == hs.dateTime; 
            }
            else 
                return false;
        }

    }
}
