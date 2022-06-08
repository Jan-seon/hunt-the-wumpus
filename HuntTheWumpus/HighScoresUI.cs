using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuntTheWumpus.HighScore;

namespace HuntTheWumpus
{
    public partial class HighScoresUI : Form
    {
        HighScoreManager highScoreManager = new HighScoreManager();

        public HighScoresUI()
        {
            InitializeComponent();

            highScoreManager.GetFromFile();
            foreach (HighScore.HighScore score in highScoreManager.GetHighScores())
            {
                richTextBoxHighScores.Text = richTextBoxHighScores.Text + $"{score.score}\t\t{score.name}\n";
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
