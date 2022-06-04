using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.Cave
{
    class Room
    {
        public int RoomNumber { get; set; }
        public Room[] Neighbors { get; set; }
        public int TunnelsAmount { get; set; }
        public int Accessible { get; set; }
        //public int Accessibility { get; set; }
        public List<Room> GateWays = new List<Room>();

        //public List<Hazard> Hazards = new List<Hazard>();

        public int Accessibility()
        {
            int accessibility = 0;
            foreach (Room tunnel in GateWays)
            {
                if (tunnel.Accessible <= Accessible)
                {
                    accessibility++;
                }
            }
            return accessibility;
        }

        //This function is for the UI to easily get the rooms it needs to put on the button.
        //When a room is null, that means thats a room you can't go to it.
        public Room[] GetGateWays()
        {
            Room[] tunnels = new Room[6];
            for (int i = 0; i < Neighbors.Length; i++)
            {
                foreach (Room tunnel in GateWays)
                {
                    if (Neighbors[i].RoomNumber == tunnel.RoomNumber)
                    {
                        tunnels[i] = Neighbors[i];
                    }
                }
            }


            Room[] output = new Room[6];
            if (RoomNumber % 2 == 0)
            {
                output = new Room[] { tunnels[0], tunnels[2], tunnels[5], tunnels[4], tunnels[3], tunnels[1] };
            }
            else
            {
                output = new Room[] { tunnels[1], tunnels[2], tunnels[4], tunnels[5], tunnels[3], tunnels[0] };
            }

            return output;
        }

        public Room(int num)
        {
            RoomNumber = num;
        }
    }
}
