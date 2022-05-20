using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuntTheWumpus.GameLocations
{
    class GameLocations
    {


        public List<GameLocations> pits = new List<GameLocations>();
        public List<GameLocations> bats = new List<GameLocations>();
        public int BatLocation { get; set; }
        public int PitLocation { get; set; }
        public int Bat1Location { get; set; }
        public int Bat2Location { get; set; }
        public int Pit1Location { get; set; }
        public int Pit2Location { get; set; }

        public int WumpusLocation { get; set; }
        public int PlayerLocation { get; set; }
        
        public Random rndInt = new Random();
        

        public GameLocations(int wumpus, int player, int pit, int bat)
        {

            wumpus = WumpusLocation;
            player = PlayerLocation;
            pit = PitLocation;
            bat = BatLocation;

            Cave cave = new Cave();
            Random rndInt = new Random();

    }
        public string GiveWarning()
        {
            return "";
        }
        public void RandomWumpus()
        {
            int num = rndInt.Next(30);
            WumpusLocation = num;
        }
        public void RandomBat()
        {
            this.Bat1Location = rndInt.Next(30);
            this.Bat2Location = rndInt.Next(30);

            bats = 

            bats.Add(Bat1Location);
            bats.Add(Bat2Location);
        }
        public void RandomPit()
        {
            int num = rndInt.Next(30);
            Pit1Location = num;
        }
        public void RandomPlayer()
        {
            int num = rndInt.Next(30);
            PlayerLocation = num;
        }
        public void ShootArrow(int aL)
        {
            if (WumpusLocation == aL)
            {

            }
            else
            {
                RandomWumpus();
            }
        }
        public string GetHint()
        {
            return "";
        }
        public void MovePlayer()
        {

        }
    }
}
