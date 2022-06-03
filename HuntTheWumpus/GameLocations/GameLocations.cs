using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HuntTheWumpus.GameLocations
{
    class GameLocations
    {
       
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
            int room = rndInt.Next(1, 30);
            WumpusLocation = room;
        }
        public void RandomBat()
        {
            Bat1Location = rndInt.Next(1, 30);
            Bat2Location = rndInt.Next(1, 30);

           
        }
        public void RandomPit()
        {
            
            Pit1Location = rndInt.Next(1, 30);
            Pit2Location = rndInt.Next(1, 30);
            
           
        }
        public void RandomPlayer()
        {
            PlayerLocation = rndInt.Next(1, 30);
        }
       
        public bool ShootArrow(int roomNumber)
        {
            if (WumpusLocation == roomNumber) return true;
            else
            {
                RandomWumpus();
                return false;
            }
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
                        hint = "There is a pit in room " + GetRoom(Pit1Location).RoomNumber.ToString();
                        return hint;
                    }
                    else if (hintOutput == 1)
                    {
                        hint = "There is a bat in room " + GetRoom(Bat1Location).RoomNumber.ToString();
                        return hint;
                    }
                    else
                    {
                        hint = "The wumpus is in room " + GetRoom(WumpusLocation).RoomNumber.ToString();
                        return hint;
                    }
                }
            }
            return "";
        }
        public Cave.Room GetRoom (int roomNumber)
        {
            return cave.Rooms[(roomNumber - 1) / 6, (roomNumber - 1) % 6]; 
        }
        
      
    }
}
