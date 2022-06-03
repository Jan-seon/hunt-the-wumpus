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
            //Made some changes, this will be the closest we can get to see if Add works as expected
            // - Mr Fernandez

            HighScoreManager highscoreManager = new HighScoreManager();
            highscoreManager.Add("A", 1, "1", DateTime.Now);
            highscoreManager.Add("B", 2, "2", DateTime.Now);

            Assert.IsFalse(highscoreManager.GetHighScores()[0] == highscoreManager.GetHighScores()[1]);
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
