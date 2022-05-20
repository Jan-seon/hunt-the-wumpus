using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.HighScore
{
    class HighScoreManager
    {

        public List<HighScore> HighScores { get; set; }

        public void Add(HighScore highscore)
        {

        }
        public void Sort()
        {

        }
        public List<HighScore> GetHighScores()
        {
            return HighScores;
        }
        public void GetFromFile(string path)
        {
            //File.IO

            //List<HighScore> highScoresFromFile = new List<HighScore>
            //Get highscoress from path
            //HighScores = highScoresFromFile

        }
        public void SaveToFile(string path)
        {
            //Save the highscores to a file
            //File.IO
        }

    }
}
