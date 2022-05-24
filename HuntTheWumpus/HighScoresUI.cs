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
        }
    }
}
