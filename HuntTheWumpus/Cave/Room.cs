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
        public Room[] GateWays { get; set; }

        //public List<Hazard> Hazards = new List<Hazard>();

        public Room(int num)
        {
            RoomNumber = num;
        }
    }
}
