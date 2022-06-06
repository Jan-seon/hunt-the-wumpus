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
    public partial class GameOverUI : Form
    {
        public bool IsVictorious { get; set; }
        public int Score { get; set; }

        public GameOverUI(bool isVict, int score)
        {
            InitializeComponent();

            IsVictorious = isVict;
            Score = score;

            labelOutcome.Text = $"You {(isVict ? "win" : "lose")}!";
            labelScore.Text = $"Score: {score}";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Hide();

            var homeScreen = new HomeScreen();
            homeScreen.FormClosed += (s, args) => this.Close();
            homeScreen.Show();
        }
    }
}
