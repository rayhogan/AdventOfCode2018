using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.Day6Stuff
{
    public class CoordinateManager
    {
        public CoordinateManager(int safeLocationThreshold)
        {
            Coords = new List<Coordinate>();
            SafeLocations = 0;
            _safeLocationThreshold = safeLocationThreshold;
        }

        public List<Coordinate> Coords;
        public int SafeLocations { get; set; }
        private int _safeLocationThreshold { get; set; }

        private Coordinate GetFurthestCoordinate()
        {
            int y = 0;

            int x = 0;

            foreach (Coordinate c in Coords)
            {
                if (x < c.x)
                    x = c.x;

                if (y < c.y)
                    y = c.y;
            }

            return new Coordinate(0, x, y);
        }

        public int CalculateLargestArea()
        {
            int area = 0;

            foreach (Coordinate c in Coords)
            {
                if (!c.isInfinite)
                {
                    if (c.count > area)
                        area = c.count;
                }
            }

            return area;
        }

        public void CalculateNearestCoordsAndSafePlaces()
        {
            // Calculate the stopping point of our grid
            Coordinate stoppingPoint = GetFurthestCoordinate();


            for (int i = 0; i < stoppingPoint.x; i++)
            {
                for (int j = 0; j < stoppingPoint.y; j++)
                {
                    // List to contain the distances
                    List<int> counts = new List<int>();
                    // ID to hold the point that is closest
                    int ID = 0;

                    // Loop through our input's co-ordinates
                    foreach (Coordinate c in Coords)
                    {
                        // Calc distance
                        int distance = Math.Abs((i - c.x)) + Math.Abs((j - c.y));
                        // Add to the list
                        counts.Add(distance);
                    }

                    // Find the smallest distance
                    int lowest = counts.Min();
                    // If the lowest value is in the list more than once then we have
                    // two equally distant points
                    int count = counts.Where(s => s == lowest).Count();

                    // If we have one instance then lets note the ID of the point
                    if (count == 1)
                        ID = (counts.IndexOf(lowest) + 1);
                    else
                        ID = 0;

                    if (ID != 0)
                    {
                        // Increment the count of the co-ord
                        Coords[ID - 1].count++;

                        // While we are here let's detect if it's an infinite coord
                        if ((!Coords[ID - 1].isInfinite) && ((i == 0) || (j == 0) || (i == stoppingPoint.x) || (j == stoppingPoint.y)))
                            Coords[ID - 1].isInfinite = true;
                    }


                    // For part 2, let's sum all the distances
                    int sum = counts.Sum();

                    if (sum < _safeLocationThreshold)
                        SafeLocations++;                    

                    
                }
            }

        }

    }
}
