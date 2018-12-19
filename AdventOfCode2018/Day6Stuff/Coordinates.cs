using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Day6Stuff
{
    public class Coordinates
    {
        public Coordinates()
        {
            Coords = new List<Coordinate>();
        }

        public List<Coordinate> Coords; 

        public Coordinate GetFurthestCoordinate()
        {
            int y = 0;

            int x = 0;

            foreach(Coordinate c in Coords)
            {
                if (x < c.x)
                    x = c.x;

                if (y < c.y)
                    y = c.y;
            }

            return new Coordinate(0, x, y);
        }

    }
}
