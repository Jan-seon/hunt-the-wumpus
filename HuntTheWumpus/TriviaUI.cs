using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntTheWumpus
{
    public partial class TriviaUI : Form
    {
        private List<Trivia.Question> questionList;
        private Trivia.Question currentQuestion;
        private int currentNumber;
        private int totalQuestions;

        public int CorrectAnswers { get; set; }

        public TriviaUI(List<Trivia.Question> questionList, string reason)
        {
            InitializeComponent();

            // Initialize class properties.
            this.questionList = questionList;
            this.currentQuestion = questionList[0];
            this.currentNumber = 0;
            this.totalQuestions = questionList.Count();

            // Set the reason.
            labelReason.Text = reason;

            // Update the UI.
            updateUI();
        }

        private void updateUI()
        {
            // Update the UI.
            labelNumber.Text = $"Question: {currentNumber+1} of {totalQuestions}";
            labelQuestion.Text = currentQuestion.TriviaQuestion;
            buttonA.Text = currentQuestion.OptionA;
            buttonB.Text = currentQuestion.OptionB;
            buttonC.Text = currentQuestion.OptionC;
            buttonD.Text = currentQuestion.OptionD;
        }

        private void userGuesses(object sender, EventArgs e)
        {
            // Check if the user is correct.
            bool isCorrect = currentQuestion.CheckAnswer(((Button)sender).Text);

            // If the user is correct...
            if (isCorrect)
            {
                // Increment the correct answers property.
                CorrectAnswers++;
            }

            // If the user has answered all questions.
            if (currentNumber == totalQuestions-1)
            {
                // Close the UI.
                this.Hide();
            }

            // Otherwise...
            else
            {
                // Retrieve the next question.
                currentNumber++;
                currentQuestion = questionList[currentNumber];

                // Update the UI.
                updateUI();
            }
        }
    }
}
