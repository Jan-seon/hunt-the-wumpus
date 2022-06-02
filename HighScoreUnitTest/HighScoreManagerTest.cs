using HuntTheWumpus.HighScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HighScoreUnitTest
{
    [TestClass]
    public class HighScoreManagerTest
    {
        [TestMethod]
        public void AddCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();

            DateTime dt = DateTime.Now;

            highscoreManager.Add("testName", 100, "1", dt);

            HighScore highscore = new HighScore("testName", 100, "1", dt);
            var getHighScore = highscoreManager.GetHighScore("testName");

            Assert.AreEqual(highscore,getHighScore);
            
        }

        [TestMethod]
        public void AddNotCorrect()
        {
            //Add function has a null or string.Empty check, will throw exception
            //Not sure how to compare since it doesn't like that Add function is void
            // - Mr. Fernandez
            /*
            HighScoreManager highscoreManager = new HighScoreManager();
            Assert.ThrowsException<Exception>(highscoreManager.Add(null, 1, null, DateTime.Now));
            */ 
        }
        [TestMethod]
        public void SortCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 85, "1", dt);

            highScoreManager.Add("A", 65, "1", dt);

            highScoreManager.Add("A", 75, "1", dt);

            highScoreManager.Sort();

            Assert.AreEqual(highScoreManager.GetHighScores()[0].score, 85);
        }
        [TestMethod]
        public void SortNotCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 85, "1", dt);

            highScoreManager.Add("A", 65, "1", dt);

            highScoreManager.Add("A", 75, "1", dt);

            highScoreManager.Sort();

            Assert.AreNotEqual(highScoreManager.GetHighScores()[0].score, 67);
        }
        [TestMethod]
        public void SaveCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 85, "1", dt);

            highScoreManager.Add("A", 65, "1", dt);

            highScoreManager.Add("A", 75, "1", dt);
            highScoreManager.SaveToFile();

            var getFromFile = highScoreManager.GetFromFile();

            Assert.IsTrue(getFromFile == highScoreManager.HighScores);
        }
        [TestMethod]
        public void SaveNotCorrect()
        {

        }
        [TestMethod]
        public void GetFromFileCorrect()
        {

        }
        [TestMethod]
        public void GetFromFileNotCorrect()
        {

        }
        [TestMethod]
        public void GetHighScoreCorrect()
        {

        }
        [TestMethod]
        public void GetHighScoreNotCorrect()
        {

        }
    }
}
