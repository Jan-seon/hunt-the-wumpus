using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuntTheWumpus.GameLocations
{
    class GameLocations
    {
        public List<Cave.Room> BatLocations { get; set; }
        public List<Cave.Room> PitLocations { get; set; }
        public int Bat1Location { get; set; }
        public int Bat2Location { get; set; }
        public int Pit1Location { get; set; }
        public int Pit2Location { get; set; }

        public int WumpusLocation { get; set; }
        public int PlayerLocation { get; set; }

        Cave.Cave cave = new Cave.Cave();
        Random rndInt = new Random();

        public GameLocations()
        {
            RandomWumpus();
            RandomBat();
            RandomPit();
            PlayerLocation = 1;

           
           }
        public List<string> GiveWarning()
        {
            List<string> warnings = new List<string>();
            Cave.Room playerRoom = GetRoom(PlayerLocation);
            foreach (Cave.Room room in playerRoom.GateWays)
            {
                if (room == GetRoom(WumpusLocation))
                {
                    warnings.Add("I smell a wumpus!");
                }
                else if (room == GetRoom(Bat1Location) || room == GetRoom(Bat2Location))
                {
                    warnings.Add("Bats nearby!");
                }
                else if (room == GetRoom(Pit1Location) || room == GetRoom(Pit2Location))
                {
                    warnings.Add("I feel a draft!");
                }
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
            Bat1Location = rndInt.Next(30);
            Bat2Location = rndInt.Next(30);

            BatLocations.Add(GetRoom(Bat1Location));
            PitLocations.Add(GetRoom(Bat2Location));
        }
        public void RandomPit()
        {
            
            Pit1Location = rndInt.Next(30);
            Pit2Location = rndInt.Next(30);
            
            PitLocations.Add(GetRoom(Pit1Location));
            PitLocations.Add(GetRoom(Pit2Location));
        }
        public void RandomPlayer()
        {
            PlayerLocation = rndInt.Next(30);
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
            string hint;
            Cave.Room playerRoom = GetRoom(PlayerLocation);
            foreach (Cave.Room room in playerRoom.GateWays)
            {
                if (room == GetRoom(WumpusLocation))
                {
                        hint = "The wumpus is within two rooms of your location.";
                        return hint;
                }
                else
                {
                    int hintOutput = rndInt.Next(3);

                    if (hintOutput == 0)
                    {
                        hint = "There is a pit in room " + GetRoom(Pit1Location).ToString();
                        return hint;
                    }
                    else if (hintOutput == 1)
                    {
                        hint = "There is a bat in room " + GetRoom(Bat1Location).ToString();
                        return hint;
                    }
                    else
                    {
                        hint = "The wumpus is in room " + GetRoom(WumpusLocation).ToString();
                        return hint;
                    }
                }
            }
            return "";
        }
        private Cave.Room GetRoom (int roomNumber)
        {
            return cave.Rooms[(roomNumber - 1) / 6, (roomNumber - 1) % 6]; 
        }
        
      
    }
}
