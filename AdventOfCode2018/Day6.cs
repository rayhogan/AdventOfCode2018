using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using AdventOfCode2018.Day6Stuff;

namespace AdventOfCode2018
{
    public static class Day6
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"..\..\..\Inputs\\Day6.txt");

            Part1and2(input);
        }

        private static void Part1and2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;
            
            CoordinateManager data = Day6.CreateDataStructure(input, 10000);
            data.CalculateNearestCoordsAndSafePlaces();
            int largestArea = data.CalculateLargestArea();

            Console.WriteLine("Largest Area: "+largestArea);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Safe Locations: "+data.SafeLocations);

        }


        public static CoordinateManager CreateDataStructure(string[] input, int safeLocationThreshold)
        {
            // Create new Coordinate manager
            CoordinateManager output = new CoordinateManager(safeLocationThreshold);
            // Start the ID numbering at 1
            int id = 1;
            
            // Loop through input and parse the X Y co-ords and add them to Co-ord manager
            foreach (string s in input)
            {
                string[] split = s.Split(',');

                int x = Convert.ToInt32(split[0].Trim());
                int y = Convert.ToInt32(split[1].Trim());

                output.Coords.Add(new Coordinate(id, y, x));
                id++;
            }

            return output;

        }

        

    }
}
