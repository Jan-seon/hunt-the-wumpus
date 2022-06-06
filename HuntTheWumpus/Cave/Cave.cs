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
        Random rnd = new Random();
        //public Room[] Rooms = new Room[30];

        public Cave()
        {
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
                    room.Neighbors = FindNeighbors(i, l);
                    room.Accessible = 0;
                    Rooms[i, l] = room;
                }
            }

            Rooms[0, 0].Accessible = 1;

            GenerateLayout();
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

        public void GenerateLayout()
        {
            foreach (Room room in Rooms)
            {
                room.TunnelsAmount = rnd.Next(1, 4);
            }

            foreach (Room room in Rooms)
            {
                List<Room> neighbors = new List<Room>();
                foreach (Room rom in room.Neighbors)
                {
                    if (rom.GateWays.Count < rom.TunnelsAmount)
                    {
                        neighbors.Add(rom);
                        //Check for duplicates
                        bool good = true;
                        foreach (Room tunnel in rom.GateWays)
                        {
                            if (tunnel.RoomNumber == rom.RoomNumber) good = false;
                        }
                        if (!good) neighbors.Remove(rom);
                    }
                }
                //Room[] tunnles;
                int tunnlesLeft = room.TunnelsAmount - room.GateWays.Count;
                for (int i = 0; i < tunnlesLeft && neighbors.Count > 0; i++)
                {
                    int n = rnd.Next(0, neighbors.Count);
                    room.GateWays.Add(neighbors[n]);
                    neighbors[n].GateWays.Add(room);

                    //Check if neighbor is more accessible
                    if ((neighbors[n].Accessible + 1 < room.Accessible && neighbors[n].Accessible > 0) || neighbors[n].RoomNumber == 1)
                    {
                        room.Accessible = neighbors[n].Accessible + 1;
                    }

                    if (room.Accessible > 0 && room.Accessible < neighbors[n].Accessible) neighbors[n].Accessible = room.Accessible + 1;
                    neighbors.RemoveAt(n);
                }
                foreach (Room tunnel in room.GateWays)
                {
                    if ((tunnel.Accessible + 1 < room.Accessible && tunnel.Accessible > 0) || tunnel.RoomNumber == 1)
                    {
                        room.Accessible = tunnel.Accessible + 1;
                    }
                }

            }

            MakeAllRoomsAccessible();
        }

        void MakeAllRoomsAccessible()
        {
            foreach (Room room in Rooms)
            {
                MakeRoomAccessible(room);
            }
            foreach (Room room in Rooms)
            {
                if (room.Accessible <= 0)
                {
                    MakeAllRoomsAccessible();
                }
            }
        }

        void MakeRoomAccessible(Room room)
        {
            //Room is not Accessible
            if (room.Accessible <= 0 && room.GateWays.Count < 3)
            {
                foreach (Room tunnel in room.GateWays)
                {
                    if (tunnel.Accessible > 0)
                    {
                        room.Accessible = tunnel.Accessible + 1;
                        MakeRoomAccessible(room);
                        return;
                    }
                }

                List<Room> neighbors = new List<Room>();
                foreach (Room neighbor in room.Neighbors)
                {
                    if (neighbor.Accessible > 0)
                    {
                        neighbors.Add(neighbor);
                        foreach (Room tunnel in room.GateWays)
                        {
                            if (neighbor.GateWays.Count >= 3)
                            {
                                //Change variable name
                                bool good = false;
                                foreach (Room t in neighbor.GateWays)
                                {
                                    if (t.Accessible < neighbor.Accessible) good = true;
                                }

                                if (!good || neighbor.Accessibility() < 2) neighbors.Remove(neighbor);
                            }

                            else if (neighbor.RoomNumber == tunnel.RoomNumber)
                            {
                                neighbors.Remove(neighbor);
                                if (tunnel.Accessible + 1 < room.Accessible || room.Accessible <= 0) room.Accessible = tunnel.Accessible + 1;
                            }
                            //else if (neighbor.Accessible + 1 < room.Accessible) room.Accessible = neighbor.Accessible + 1;
                        }
                        if (room.Accessible > 0) return;
                    }
                }

                if (neighbors.Count > 0)
                {
                    int n = rnd.Next(0, neighbors.Count);

                    if (neighbors[n].GateWays.Count >= 3)
                    {
                        List<Room> idk = new List<Room>();
                        foreach (Room t in neighbors[n].GateWays)
                        {
                            if (t.Accessible < neighbors[n].Accessible) idk.Add(t);
                        }
                        int r = rnd.Next(0, idk.Count);
                        idk[r].GateWays.Remove(neighbors[n]);
                        neighbors[n].GateWays.Remove(idk[r]);
                    }

                    room.GateWays.Add(neighbors[n]);
                    neighbors[n].GateWays.Add(room);
                    MakeRoomAccessible(neighbors[n]);
                }
            }


            //Room is already accessible
            else if (room.Accessible > 0)
            {
                foreach (Room tunnel in room.GateWays)
                {
                    if (tunnel.Accessible <= 0)
                    {
                        tunnel.Accessible = room.Accessible + 1;
                        MakeRoomAccessible(tunnel);
                    }
                    else if (tunnel.Accessible + 1 < room.Accessible)
                    {
                        room.Accessible = tunnel.Accessible + 1;
                    }
                }

            }
            return;
        }
    }
}
