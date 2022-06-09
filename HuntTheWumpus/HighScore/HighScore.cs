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
        public int turns { get; set; }
        public int goldLeft { get; set; }
        public int arrowsLeft { get; set; }
        public bool isWumpKilled { get; set; }


        public HighScore(string n, int s, string cn, DateTime dt, int t, int gL, int aL, bool iWK)
        {
            name = n;
            score = s;
            caveName = cn;
            dateTime = dt;
            turns = t;
            goldLeft = gL;
            arrowsLeft = aL;
            isWumpKilled = iWK; 

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
