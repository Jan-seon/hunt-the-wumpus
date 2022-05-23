using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus.Cave
{
    class Cave
    {
        //public static Room[,] Rooms { new Room[5, 6]; set; }
        public Room[,] Rooms = new Room[5, 6];
        //public Room[] Rooms = new Room[30];

        public Cave()
        {
            //for (int i = 0; i < Rooms.Length; i++)
            //{
            //    Room room = new Room(i + 1);
            //    Rooms[i] = room;
            //}

            for (int i = 0; i < 5; i++)
            {
                for (int l = 0; l < 6; l++)
                {
                    Room room = new Room((l + 1) + (i * 6));
                    Rooms[i, l] = room;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int l = 0; l < 6; l++)
                {
                    Room room = Rooms[i, l];
                    room.GateWays = FindNeighbors(i, l);
                    Rooms[i, l] = room;
                }
            }
        }

        private int GetRow(int index, int num)
        {
            int n = index;
            if (num <= 0)
            {
                for (int i = 0; i < Math.Abs(num); i++)
                {
                    if (n <= 0)
                    {
                        n = 4;
                    }
                    else
                    {
                        n--;
                    }
                }
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    if (n >= 4)
                    {
                        n = 0;
                    }
                    else
                    {
                        n++;
                    }
                }
            }
            return n;
        }

        private int GetColum(int index, int num)
        {
            int n = index;
            if (num <= 0)
            {
                for (int i = 0; i < Math.Abs(num); i++)
                {
                    if (n <= 0)
                    {
                        n = 5;
                    }
                    else
                    {
                        n--;
                    }
                }
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    if (n >= 5)
                    {
                        n = 0;
                    }
                    else
                    {
                        n++;
                    }
                }
            }
            return n;
        }

        public Room[] FindNeighbors(int row, int index)
        {
            Room room = Rooms[row, index];
            Room r1;
            Room r2;
            Room r3;
            Room r4;
            Room r5;
            Room r6;

            if (room.RoomNumber % 2 == 0)
            {
                r1 = Rooms[row, GetColum(index, -1)];
                r2 = Rooms[GetRow(row, -1), index];
                r3 = Rooms[row, GetColum(index, 1)];
                r4 = Rooms[GetRow(row, 1), GetColum(index, -1)];
                r5 = Rooms[GetRow(row, 1), index];
                r6 = Rooms[GetRow(row, 1), GetColum(index, 1)];

                return new Room[] { r1, r2, r3, r4, r5, r6 };
            }
            else
            {
                r1 = Rooms[GetRow(row, -1), GetColum(index, -1)];
                r2 = Rooms[GetRow(row, -1), index];
                r3 = Rooms[GetRow(row, -1), GetColum(index, 1)];
                r4 = Rooms[row, GetColum(index, -1)];
                r5 = Rooms[row, GetColum(index, 1)];
                r6 = Rooms[GetRow(row, 1), index];

                return new Room[] { r1, r2, r3, r4, r5, r6 };
            }
        }
    }
}
