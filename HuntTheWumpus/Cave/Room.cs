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

        public Room(int num)
        {
            RoomNumber = num;
        }
    }
}
