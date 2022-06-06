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

            highscoreManager.Add("testName", 100, "1", dt, 0, 0, 0, true);

            HighScore highscore = new HighScore("testName", 100, "1", dt, 0, 0, 0, true);
            var getHighScore = highscoreManager.GetHighScore("testName");

            Assert.AreEqual(highscore,getHighScore);
            
        }

        [TestMethod]
        public void AddNotCorrect()
        {
            //Made some changes, this will be the closest we can get to see if Add works as expected
            // - Mr Fernandez

            HighScoreManager highscoreManager = new HighScoreManager();
            highscoreManager.Add("A", 1, "1", DateTime.Now, 0, 0, 0, true);
            highscoreManager.Add("B", 2, "2", DateTime.Now, 0, 0, 0, true);

            Assert.IsFalse(highscoreManager.GetHighScores()[0] == highscoreManager.GetHighScores()[1]);
        }
        [TestMethod]
        public void SortCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 85, "1", dt, 0, 0, 0, true);

            highScoreManager.Add("A", 65, "1", dt, 0, 0, 0, true);

            highScoreManager.Add("A", 75, "1", dt, 0, 0, 0, true);

            highScoreManager.Sort();

            Assert.AreEqual(highScoreManager.GetHighScores()[0].score, 85);
        }
        [TestMethod]
        public void SortNotCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 81, "1", dt, 0, 0, 0, true);

            highScoreManager.Add("A", 62, "1", dt, 0, 0, 0, true);

            highScoreManager.Add("A", 73, "1", dt, 0, 0, 0, true);

            highScoreManager.Sort();

            Assert.AreNotEqual(highScoreManager.GetHighScores()[0].score, 67);
        }
        [TestMethod]
        public void SaveCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 85, "1", dt, 1, 2, 3, true);

            highScoreManager.Add("A", 65, "1", dt, 4, 5, 6, true);

            highScoreManager.Add("A", 75, "1", dt, 7, 8, 9, true);
            highScoreManager.SaveToFile();

            var getFromFile = highScoreManager.GetFromFile();

            Assert.IsTrue(getFromFile == highScoreManager.HighScores);
        }
        [TestMethod]
        public void SaveNotCorrect()
        {
            HighScoreManager highScoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highScoreManager.Add("A", 82, "1", dt, 10, 11, 12, true);

            highScoreManager.Add("A", 67, "1", dt, 13, 14, 15, true);

            highScoreManager.Add("A", 79, "1", dt, 16, 17, 18, true);
            highScoreManager.SaveToFile();

            var getFromFile = highScoreManager.GetFromFile();

            Assert.IsFalse(getFromFile != highScoreManager.HighScores);
        }
        [TestMethod]
        public void GetFromFileCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highscoreManager.Add("A", 85, "1", dt, 1, 2, 3, true);
            highscoreManager.SaveToFile();
            var getFromFile = highscoreManager.GetFromFile();

            Assert.IsTrue(getFromFile == highscoreManager.HighScores);



        }
        [TestMethod]
        public void GetFromFileNotCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();
            DateTime dt = DateTime.Now;
            highscoreManager.Add("A", 85, "1", dt, 1, 2, 3, true);
            highscoreManager.SaveToFile();
            var getFromFile = highscoreManager.GetFromFile();

            Assert.IsFalse(getFromFile != highscoreManager.HighScores);
        }
        [TestMethod]
        public void GetHighScoreCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();

            DateTime dt = DateTime.Now;

            highscoreManager.Add("testName", 100, "1", dt, 0, 0, 0, true);

            HighScore highscore = new HighScore("testName", 100, "1", dt, 0, 0, 0, true);
            var getHighScore = highscoreManager.GetHighScore("testName");

            Assert.AreEqual(highscore, getHighScore);
        }
        [TestMethod]
        public void GetHighScoreNotCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();
            highscoreManager.Add("A", 1, "1", DateTime.Now, 0, 0, 0, true);
            highscoreManager.Add("B", 2, "2", DateTime.Now, 0, 0, 0, true);

            Assert.IsFalse(highscoreManager.GetHighScores()[0] == highscoreManager.GetHighScores()[1]);
        }
    
        [TestMethod]
        public void GetHighScoresCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();

            DateTime dt = DateTime.Now;

            highscoreManager.Add("testName", 100, "1", dt, 0, 0, 0, true);

            HighScore highscore = new HighScore("testName", 100, "1", dt, 0, 0, 0, true);
            var getHighScore = highscoreManager.GetHighScore("testName");

            Assert.AreEqual(highscore, getHighScore);
        }
        [TestMethod]
        public void GetHighScoresNotCorrect()
        {
            HighScoreManager highscoreManager = new HighScoreManager();
            highscoreManager.Add("B", 2, "2", DateTime.Now, 0, 0, 0, true);
            highscoreManager.Add("C", 3, "3", DateTime.Now, 0, 0, 0, true);

            Assert.IsFalse(highscoreManager.GetHighScores()[0] == highscoreManager.GetHighScores()[1]);
        }
    }
}
