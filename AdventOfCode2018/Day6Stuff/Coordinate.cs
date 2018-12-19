using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Day6Stuff
{
    public class Coordinate
    {
        public Coordinate(int _id, int _x, int _y)
        {
            x = _x;
            y = _y;
            id = _id;
            count = 1;
        }

        public int id { get; }
        public int x { get; set; }
        public int y { get; set; }

        public int count { get; set; }
    }
}
