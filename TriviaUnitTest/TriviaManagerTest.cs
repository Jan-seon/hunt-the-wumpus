using Microsoft.VisualStudio.TestTools.UnitTesting;
using HuntTheWumpus.Trivia;
using System;

namespace TriviaUnitTest
{
    [TestClass]
    public class TriviaManagerTest
    {
        [TestMethod]
        public void QuestionQuantityCorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreEqual(triviaManager.GetRandomQuestion(3).Count, 3);
        }

        [TestMethod]
        public void QuestionQuantityIncorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreNotEqual(triviaManager.GetRandomQuestion(5).Count, 3);
        }

        [TestMethod]
        public void CorrectGuess()
        {
            Question question = new Question("test", "a", "b", "c", "d", "b");

            string guess = "b";
            Assert.IsTrue(question.CheckAnswer(guess));
        }

        [TestMethod]
        public void IncorrectGuess()
        {
            Question question = new Question("test", "a", "b", "c", "d", "b");

            string guess = "c";
            Assert.IsFalse(question.CheckAnswer(guess));
        }
    }
}
