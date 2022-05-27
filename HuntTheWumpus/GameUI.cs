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
    public partial class GameUI : Form
    {
        private GameLocations.GameLocations gameLocations = new GameLocations.GameLocations();
        private HighScore.HighScoreManager highScoreManager = new HighScore.HighScoreManager();
        private Player.Player player = new Player.Player();
        private Trivia.TriviaManager triviaManager = new Trivia.TriviaManager();

        private bool shooting = false;

        public GameUI()
        {
            InitializeComponent();
        }

        private void move(object sender, EventArgs e)
        {
            if (shooting)
            {

            }
            else
            {
                // update player location
                // update player turns

                // check for hazards

                // check for warnings
            }
        }

        private void shootArrow(object sender, EventArgs e)
        {
            shooting = !shooting;
            enableUI(!shooting);

            updateUI();
        }

        private void purchaseArrow(object sender, EventArgs e)
        {
            List<Trivia.Question> questions = triviaManager.GetRandomQuestion(3);

            TriviaUI triviaUI = new TriviaUI(questions);
            triviaUI.ShowDialog();

            if (triviaUI.CorrectAnswers >= 2)
            {
                // player.PurchaseArrows();
            }

            triviaUI.Close();
            updateUI();
        }

        private void purchaseSecret(object sender, EventArgs e)
        {
            List<Trivia.Question> questions = triviaManager.GetRandomQuestion(3);

            TriviaUI triviaUI = new TriviaUI(questions);
            triviaUI.ShowDialog();

            if (triviaUI.CorrectAnswers >= 2)
            {
                // player.PurchaseSecret();
                string hint = gameLocations.GetHint();
                richTextBoxHints.Text = $"{hint}\n{richTextBoxHints.Text}";
            }

            triviaUI.Close();
            updateUI();
        }

        private void enableUI(bool enable)
        {
            buttonPurchaseArrows.Enabled = enable;
            buttonPurchaseSecret.Enabled = enable;
        }

        private void updateUI()
        {
            labelCoins.Text = player.Coins.ToString();
            labelArrows.Text = player.Arrows.ToString();
            labelScore.Text = player.CalculateScore(false).ToString();

            Cave.Room room = gameLocations.GetRoom(gameLocations.PlayerLocation);
            Cave.Room[] neighbors = room.Neighbors;
            List<Cave.Room> gateways = room.GateWays;

            //buttonMove1.Text = neighbors
        }
    }
}
