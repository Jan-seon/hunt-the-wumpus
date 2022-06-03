using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuntTheWumpus.HighScore
{
    public class HighScoreManager
    {

        public List<HighScore> HighScores { get; set; } = new List<HighScore>();

        public void Add( string n, int s, string cn, DateTime dt)
        {
            if (string.IsNullOrEmpty(n) || string.IsNullOrEmpty(cn))
                throw new Exception();

            HighScore highscore = new HighScore(n, s, cn, dt);
            HighScores.Add(highscore);
            Sort(); 

            

        }
        public void Sort()
        {
           HighScores = HighScores.OrderByDescending(x => x.score).ToList(); 
           if(HighScores.Count > 10)
            {
                HighScores.RemoveAt(10); 
            }

        }

        public HighScore GetHighScore(string name)
        {
            foreach(HighScore highscore in HighScores)
            {
                if (highscore.name == name)
                    return highscore;
            }

            return null;
        }

        public List<HighScore> GetHighScores()
        {
            return HighScores;
        }
        public List<HighScore> GetFromFile()
        {
            List<HighScore> highScoresFromFile = new List<HighScore>();
            using (StreamReader sr = new StreamReader("HighScore/HighscoreFile.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] highScore = sr.ReadLine().Split(',');
                    HighScore highScoreObject = new HighScore(highScore[0], Convert.ToInt32(highScore[1]), highScore[2], Convert.ToDateTime(highScore[3]));
                    highScoresFromFile.Add(highScoreObject);
                }
            }
            HighScores = highScoresFromFile;
            return HighScores;

        }
        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter("HighScore/HighscoreFile.txt"))
            {
                foreach(HighScore highScore in HighScores)
                {
                    sw.WriteLine(highScore.name + "," + highScore.score + "," + highScore.caveName + "," + highScore.dateTime);
                }
            }
            
        }

    }
}
