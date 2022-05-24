using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuntTheWumpus.GameLocations
{
    class GameLocations
    {
        public int BatLocation { get; set; }
        public int PitLocation { get; set; }
        public int Bat1Location { get; set; }
        public int Bat2Location { get; set; }
        public int Pit1Location { get; set; }
        public int Pit2Location { get; set; }

        public int WumpusLocation { get; set; }
        public int PlayerLocation { get; set; }

        Cave.Cave cave = new Cave.Cave();
        Random rndInt = new Random();
        List<Cave.Room> pits = new List<Cave.Room>();
        List<Cave.Room> bats = new List<Cave.Room>();

        public GameLocations(int wumpus, int player, int pit, int bat)
        {

            wumpus = WumpusLocation;
            player = PlayerLocation;
            pit = PitLocation;
            bat = BatLocation;

           
    }
        public List<string> GiveWarning()
        {
            List<string> warnings = new List<string>();
            if (PlayerLocation == WumpusLocation)
            {
                warnings.Add("I smell a wumpus!");
            }
            else if (PlayerLocation == Bat1Location || PlayerLocation == Bat2Location)
            {
                warnings.Add("Bats nearby!");
            }
            else if(PlayerLocation == Pit1Location || PlayerLocation == Pit2Location)
            {
                warnings.Add("I feel a draft!");
            }
            return warnings;
        }
        public void RandomWumpus()
        {
            WumpusLocation = 0;
            int room = rndInt.Next(30);
            WumpusLocation = room;
        }
        public void RandomBat()
        {
            this.Bat1Location = rndInt.Next(30);
            this.Bat2Location = rndInt.Next(30);

            bats.Add(Bat1Location);
            bats.Add(Bat2Location);
        }
        public void RandomPit()
        {
            
            int room1, room2;
            room1 = rndInt.Next(30);
            room2 = rndInt.Next(30);
            Pit1Location = room1;
            Pit2Location = room2;

            pits.Add(Pit1Location);
            pits.Add(Pit2Location);
        }
        public void RandomPlayer()
        {
            PlayerLocation = 0;
            int room = rndInt.Next(30);
            PlayerLocation = room;
        }
        public bool ShootArrow(int roomNumber)
        {
            bool winOrLose = false;
            if (WumpusLocation == roomNumber)
            {
                winOrLose = true;
                
            }
            else
            {
                RandomWumpus();
            }
            return winOrLose;
        }
        public string GetHint()
        {
            return "";
        }
      
    }
}
