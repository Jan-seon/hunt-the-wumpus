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
        private Player.Player player = new Player.Player();
        private Trivia.TriviaManager triviaManager = new Trivia.TriviaManager();

        private bool shooting = false;

        public GameUI()
        {
            InitializeComponent();
            updateUI();
        }

        private int getButtonNumber(object sender)
        {
            // Return the room number of the button the user clicks.
            return int.Parse(((Button)sender).Text);
        }

        private void move(object sender, EventArgs e)
        {
            if (shooting)
            {
                // Shoot an arrow.
                shootArrow(getButtonNumber(sender));
            }
            else
            {
                // Update the player location.
                gameLocations.PlayerLocation = getButtonNumber(sender);

                // Update the player information.
                player.Move();

                // Update the UI.
                updateUI();

                // Check if player encounters a hazard.
                encounterBat();
                encounterPit();
                encounterWumpus();
            }
        }

        private void shootArrow(int room)
        {
            // Update player information.
            player.ShotArrow();

            // Check if player hits the wumpus.
            bool gameOver = gameLocations.ShootArrow(room);

            // Update the UI.
            shooting = !shooting;
            enableUI(!shooting);
            updateUI();

            // If player hits the wumpus...
            if (gameOver)
            {
                // End the game.
                endGame(true);
            }
            
            // If player misses the wumpus...
            else
            {
                // Notify the player.
                labelMessage.Text = "You missed.";

                // Generate a new wumpus location.
                gameLocations.RandomWumpus();
            }
        }

        private void encounterWumpus()
        {
            // Retrieve the locations.
            Cave.Room playerRoom = gameLocations.GetRoom(gameLocations.PlayerLocation);
            Cave.Room wumpusRoom = gameLocations.GetRoom(gameLocations.WumpusLocation);

            // If the player is in the same room...
            if (playerRoom.RoomNumber == wumpusRoom.RoomNumber)
            {
                // Retrieve five random questions.
                List<Trivia.Question> questions = triviaManager.GetRandomQuestion(5);

                // Create a new trivia UI.
                TriviaUI triviaUI = new TriviaUI(questions, "You encountered a wumpus.");
                triviaUI.ShowDialog();

                // If the user answers at least two questions correctly...
                if (triviaUI.CorrectAnswers >= 3)
                {
                    // Change the wumpus location.
                    gameLocations.RandomWumpus();

                    // Update the UI.
                    updateUI();

                    // Notify the user.
                    labelMessage.Text = "The wumpus ran away.";
                }

                // If the user fails trivia...
                else
                {
                    // End the game.
                    endGame(false);
                }

                // Close the trivia objects.
                triviaUI.Close();
            }
        }

        private void encounterBat()
        {
            // Retrieve the locations.
            Cave.Room playerRoom = gameLocations.GetRoom(gameLocations.PlayerLocation);
            Cave.Room batRoom1 = gameLocations.GetRoom(gameLocations.Bat1Location);
            Cave.Room batRoom2 = gameLocations.GetRoom(gameLocations.Bat2Location);

            // If the player is in the same room...
            if (playerRoom.RoomNumber == batRoom1.RoomNumber || playerRoom.RoomNumber == batRoom2.RoomNumber)
            {
                // Change the player's locations.
                gameLocations.RandomPlayer();

                // Change the bat locations.
                gameLocations.RandomBat();

                // Update the UI.
                updateUI();

                // Notify the user.
                labelMessage.Text = "You encountered a bat.";
            }  
        }

        private void encounterPit()
        {
            // Retrieve the locations.
            Cave.Room playerRoom = gameLocations.GetRoom(gameLocations.PlayerLocation);
            Cave.Room pitRoom1 = gameLocations.GetRoom(gameLocations.Pit1Location);
            Cave.Room pitRoom2 = gameLocations.GetRoom(gameLocations.Pit2Location);

            // If the player is in the same room...
            if (playerRoom.RoomNumber == pitRoom1.RoomNumber || playerRoom.RoomNumber == pitRoom2.RoomNumber)
            {
                // Retrieve three random questions.
                List<Trivia.Question> questions = triviaManager.GetRandomQuestion(3);

                // Create a new trivia UI.
                TriviaUI triviaUI = new TriviaUI(questions, "You encountered a pit.");
                triviaUI.ShowDialog();

                // If the user answers at least two questions correctly...
                if (triviaUI.CorrectAnswers >= 2)
                {
                    // Move the player back to room 1.
                    gameLocations.PlayerLocation = 1;

                    // Change the pit locations.
                    gameLocations.RandomPit();

                    // Update the UI.
                    updateUI();

                    // Notify the user.
                    labelMessage.Text = "You escaped the pit.";
                }

                // If the user fails trivia...
                else
                {
                    // End the game.
                    endGame(false);
                }

                // Close the trivia objects.
                triviaUI.Close();
            }
        }

        private void shootArrowButtonClick(object sender, EventArgs e)
        {
            // Update the UI.
            shooting = !shooting;
            enableUI(!shooting);
            updateUI();

            // If the player enables shooting mode...
            if (shooting)
                // Notify the user.
                labelMessage.Text = "Shooting...";
        }

        private void purchaseArrow(object sender, EventArgs e)
        {
            // Retrieve three random questions.
            List<Trivia.Question> questions = triviaManager.GetRandomQuestion(3);

            // Create a new trivia UI.
            TriviaUI triviaUI = new TriviaUI(questions, "You are purchasing arrows.");
            triviaUI.ShowDialog();

            // If the user answers at least two questions correctly...
            if (triviaUI.CorrectAnswers >= 2)
            {
                // Buy arrows.
                player.PurchaseArrows();

                // Update the UI.
                updateUI();

                // Notify the user.
                labelMessage.Text = "You bought 2 arrows!";
            }

            // If the user fails trivia...
            else
            {
                // Notify the user.
                labelMessage.Text = "You failed.";
            }

            // Close the trivia objects.
            triviaUI.Close();
        }

        private void purchaseSecret(object sender, EventArgs e)
        {
            // Retrive three random questions.
            List<Trivia.Question> questions = triviaManager.GetRandomQuestion(3);

            // Create a new trivia UI.
            TriviaUI triviaUI = new TriviaUI(questions, "You are purchasing a secret.");
            triviaUI.ShowDialog();

            // If the user answers at least two questions correctly...
            if (triviaUI.CorrectAnswers >= 2)
            {
                // Update the player information.
                player.PurchaseSecret();

                // Retrieve a random hint.
                string hint = gameLocations.GetHint();

                // Display the hint.
                richTextBoxHints.Text = $"{hint}\n{richTextBoxHints.Text}";

                // Update the UI.
                updateUI();

                // Notify the user.
                labelMessage.Text = "You bought a hint!";
            }

            // If the user fails trivia...
            else
            {
                labelMessage.Text = "You failed.";
            }
            
            // Close the trivia UI.
            triviaUI.Close();
        }

        private void enableUI(bool enable)
        {
            // Enable/Disable the buttons.
            buttonPurchaseArrows.Enabled = enable;
            buttonPurchaseSecret.Enabled = enable;
        }

        private void updateUI()
        {
            // Update the player information.
            labelCoins.Text = player.Coins.ToString();
            labelArrows.Text = player.Arrows.ToString();
            labelScore.Text = player.CalculateScore(false).ToString();

            // Check if the player has enough arrows to shoot.
            if (player.Arrows >= 1)
                buttonShootArrow.Enabled = true;
            else
                buttonShootArrow.Enabled = false;

            // Check if the player has enough gold.
            if (player.Coins >= 1)
            {
                buttonPurchaseArrows.Enabled = true;
                buttonPurchaseSecret.Enabled = true;
            }
            else
            {
                buttonPurchaseArrows.Enabled = false;
                buttonPurchaseSecret.Enabled = false;
            }

            // If their is a message, remove it.
            if (labelMessage.Text != "")
            {
                labelMessage.Text = "";
            }

            // Check for warnings
            List<string> warnings = gameLocations.GiveWarning();

            // Display the warnings.
            richTextBoxWarnings.Text = "";
            foreach (string warning in warnings)
            {
                richTextBoxWarnings.Text = $"{richTextBoxWarnings.Text}{warning}\n";
            }

            // Get the room object of the player.
            Cave.Room room = gameLocations.GetRoom(gameLocations.PlayerLocation);

            // Get the gateways.
            Cave.Room[] gateways = room.GetGateWays();

            // Create a list of all the buttons.
            Button[] allMoveButtons = { buttonMove1, buttonMove2, buttonMove3,
                    buttonMove4, buttonMove5, buttonMove6};

            // Display the room number.
            labelCurrentRoom.Text = room.RoomNumber.ToString();

            // Loop through the rooms.
            for (int i = 0; i < 6; i++)
            {
                // If there is not a gateway...
                if (gateways[i] == null)
                {
                    // Make the button invisible.
                    allMoveButtons[i].Visible = false;
                }

                // If there is a gateway...
                else
                {
                    // Update the button number.
                    allMoveButtons[i].Text = gateways[i].RoomNumber.ToString();

                    // Make the button visible.
                    allMoveButtons[i].Visible = true;
                }
            }
        }

        private void endGame(bool isVictorious)
        {
            // Calculate the score.
            int score = player.CalculateScore(isVictorious);

            // Open the game over UI.
            this.Hide();
            var gameOverUI = new GameOverUI(isVictorious, score, player.Turns, player.Coins, player.Arrows);
            gameOverUI.Closed += (s, args) => this.Close();
            gameOverUI.Show();
        }
    }
}
