using Microsoft.VisualStudio.TestTools.UnitTesting;
using HuntTheWumpus.Trivia;
using System;

namespace TriviaUnitTest
{
    [TestClass]
    public class TriviaManagerTest
    {
        // see if the trivia manager has gotten the right amount of questions requested
        [TestMethod]
        public void QuestionQuantityCorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreEqual(triviaManager.GetRandomQuestion(3).Count, 3);
        }

        // see if the trivia manager has gotten the wrong amount of questions requested
        [TestMethod]
        public void QuestionQuantityIncorrect()
        {
            TriviaManager triviaManager = new TriviaManager();

            triviaManager.ReadFile();
            Assert.AreNotEqual(triviaManager.GetRandomQuestion(5).Count, 3);
        }

        // see if the trivia manager can tell when you get the question correct
        [TestMethod]
        public void CorrectGuess()
        {
            Question question = new Question("test", "a", "b", "c", "d", "b");

            string guess = "b";
            Assert.IsTrue(question.CheckAnswer(guess));
        }

        // see if the trivia manager can tell when you get the question incorrect
        [TestMethod]
        public void IncorrectGuess()
        {
            Question question = new Question("test", "a", "b", "c", "d", "b");

            string guess = "c";
            Assert.IsFalse(question.CheckAnswer(guess));
        }
    }
}
