using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
           HighScores = HighScores.OrderByDescending(x => x.score).ToList(); 
           if(HighScores.Count > 10)
            {
                HighScores.RemoveAt(10); 
            }

        }
        public List<HighScore> GetHighScores()
        {
            return HighScores;
        }
        public void GetFromFile(string path)
        {
           

            List<HighScore> highScoresFromFile = new List<HighScore>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] highScore = sr.ReadLine().Split(',');
                    HighScore highScoreObject = new HighScore(highScore[0], Convert.ToInt32(highScore[1]), highScore[2], Convert.ToDateTime(highScore[3]));
                    highScoresFromFile.Add(highScoreObject);
                }
            }
            HighScores = highScoresFromFile;

        }
        public void SaveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach(HighScore highScore in HighScores)
                {
                    sw.WriteLine(highScore.name, highScore.score, highScore.caveName, highScore.dateTime);
                }
            }
            
        }

    }
}
