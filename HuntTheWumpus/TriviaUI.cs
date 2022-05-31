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

        public TriviaUI(List<Trivia.Question> questionList)
        {
            InitializeComponent();

            this.questionList = questionList;
            this.currentQuestion = questionList[0];
            this.currentNumber = 1;
            this.totalQuestions = questionList.Count();

            updateUI();
        }

        private void updateUI()
        {
            labelNumber.Text = $"Question: {currentNumber} of {totalQuestions}";
            labelQuestion.Text = currentQuestion.TriviaQuestion;
            buttonA.Text = currentQuestion.OptionA;
            buttonB.Text = currentQuestion.OptionB;
            buttonC.Text = currentQuestion.OptionC;
            buttonD.Text = currentQuestion.OptionD;
        }

        private void userGuesses(object sender, EventArgs e)
        {
            bool isCorrect = currentQuestion.CheckAnswer(((Button)sender).Text);

            if (isCorrect)
            {
                CorrectAnswers++;
            }

            if (currentNumber == totalQuestions)
            {

            }
            else
            {
                currentNumber++;
                currentQuestion = questionList[currentNumber];

                updateUI();
            }
        }
    }
}
