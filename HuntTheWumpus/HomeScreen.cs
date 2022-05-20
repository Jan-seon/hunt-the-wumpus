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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();

            var gameUI = new GameUI();
            gameUI.Closed += (s, args) => this.Close();
            gameUI.Show();
        }

        private void buttonHighScores_Click(object sender, EventArgs e)
        {
            this.Hide();

            var highScoreUI = new HighScoresUI();
            highScoreUI.FormClosed += (s, args) => this.Close();
            highScoreUI.Show();
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            this.Hide();

            var creditsUI = new CreditsUI();
            creditsUI.FormClosed += (s, args) => this.Close();
            creditsUI.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
