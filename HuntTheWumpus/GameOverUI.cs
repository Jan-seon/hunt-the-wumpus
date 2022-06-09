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
        public int Turns { get; set; }
        public int Gold { get; set; }
        public int Arrows { get; set; }

        private HighScore.HighScoreManager highScoreManager = new HighScore.HighScoreManager();

        public GameOverUI(bool isVict, int score, int turns, int gold, int arrows)
        {
            InitializeComponent();

            IsVictorious = isVict;
            Score = score;
            Turns = turns;
            Gold = gold;
            Arrows = arrows;

            labelOutcome.Text = $"You {(isVict ? "win" : "lose")}!";
            labelScore.Text = $"Score: {score}";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            highScoreManager.GetFromFile();
            highScoreManager.Add(textBoxName.Text, Score, "N/A", DateTime.Now, Turns, Gold, Arrows, IsVictorious);
            highScoreManager.SaveToFile();

            this.Hide();
            var homeScreen = new HomeScreen();
            homeScreen.FormClosed += (s, args) => this.Close();
            homeScreen.Show();
        }
    }
}
