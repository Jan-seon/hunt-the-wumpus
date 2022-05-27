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
                player.Move();

                // check for hazards

                // check for warnings
            }
        }

        private void shootArrow(object sender, EventArgs e)
        {
            shooting = !shooting;
            enableUI(!shooting);

            updateUI();

            player.ShotArrow();
        }

        private void purchaseArrow(object sender, EventArgs e)
        {
            List<Trivia.Question> questions = triviaManager.GetRandomQuestion(3);
            
            player.PurchaseArrows();

            updateUI();
        }

        private void purchaseSecret(object sender, EventArgs e)
        {
            player.PurchaseSecret();
            string hint = gameLocations.GetHint();
            richTextBoxHints.Text = $"{hint}\n{richTextBoxHints.Text}";

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
            //labelScore.Text = player.CalculateScore().ToString();
            
            // get gateways
            // update labels
        }
    }
}
