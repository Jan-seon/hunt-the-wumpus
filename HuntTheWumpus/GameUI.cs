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
        private Cave.Cave cave = new Cave.Cave();
        private GameLocations.GameLocations gameLocations = new GameLocations.GameLocations(0, 0, 0, 0);
        private HighScore.HighScoreManager highScoreManager = new HighScore.HighScoreManager();
        private Player.Player player = new Player.Player();
        private Trivia.TriviaManager triviaManager = new Trivia.TriviaManager();

        private bool shooting = false;

        public GameUI()
        {
            InitializeComponent();
        }

        private void shootArrow(object sender, EventArgs e)
        {
            shooting = !shooting;

            if (shooting)
            {
                enableUI(false);
            }
            else
            {
                enableUI(true);
            }
        }

        private void purchaseArrow(object sender, EventArgs e)
        {
            // player purchaseArrow
        }

        private void purchaseSecret(object sender, EventArgs e)
        {
            // player purchaseSecret
            string hint = gameLocations.GetHint();

        }

        private void enableUI(bool enable)
        {
            buttonPurchaseArrows.Enabled = enable;
            buttonPurchaseArrows.Enabled = enable;
        }
    }
}
