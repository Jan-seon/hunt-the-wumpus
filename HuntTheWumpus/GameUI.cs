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
            updateUI();
        }

        private void move(object sender, EventArgs e)
        {
            if (shooting)
            {

            }
            else
            {
                gameLocations.PlayerLocation = int.Parse(((Button)sender).Text);
                player.Move();

                List<string> warnings = gameLocations.GiveWarning();

                richTextBoxWarnings.Text = "";
                foreach(string warning in warnings)
                {
                    richTextBoxWarnings.Text = $"{richTextBoxWarnings.Text}{warning}\n";
                }

                updateUI();
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
                player.PurchaseArrows();
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
                player.PurchaseSecret();
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

            List<int> gatewaysNumbers = new List<int>();
            foreach(Cave.Room gateway in gateways)
                gatewaysNumbers.Add(gateway.RoomNumber);

            labelCurrentRoom.Text = room.RoomNumber.ToString();

            buttonMove1.Text = neighbors[0].RoomNumber.ToString();
            buttonMove2.Text = neighbors[1].RoomNumber.ToString();
            buttonMove3.Text = neighbors[2].RoomNumber.ToString();
            buttonMove4.Text = neighbors[3].RoomNumber.ToString();
            buttonMove5.Text = neighbors[4].RoomNumber.ToString();
            buttonMove6.Text = neighbors[5].RoomNumber.ToString();

            /*            if (gatewaysNumbers.Contains(neighbors[0].RoomNumber))
                            buttonMove1.Text = neighbors[0].RoomNumber.ToString();
                        if (gatewaysNumbers.Contains(neighbors[1].RoomNumber))
                            buttonMove2.Text = neighbors[1].RoomNumber.ToString();
                        if (gatewaysNumbers.Contains(neighbors[2].RoomNumber))
                            buttonMove3.Text = neighbors[2].RoomNumber.ToString();
                        if (gatewaysNumbers.Contains(neighbors[3].RoomNumber))
                            buttonMove4.Text = neighbors[3].RoomNumber.ToString();
                        if (gatewaysNumbers.Contains(neighbors[4].RoomNumber))
                            buttonMove5.Text = neighbors[4].RoomNumber.ToString();
                        if (gatewaysNumbers.Contains(neighbors[5].RoomNumber))
                            buttonMove6.Text = neighbors[5].RoomNumber.ToString();*/
        }
    }
}
