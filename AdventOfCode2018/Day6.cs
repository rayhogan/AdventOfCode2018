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
            string[] input = Helper.ParseInput(@"Inputs\\Day6.txt");

            Part1(input);
            Part2(input);
        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            Coordinates coords = CreateDataStructure(input);

            Console.WriteLine("");

        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");

        }

        public static Coordinates CreateDataStructure(string[] input)
        {
            Coordinates output = new Coordinates();
            int id = 1;
            foreach (string s in input)
            {
                string[] split = s.Split(',');

                int x = Convert.ToInt32(split[0].Trim());
                int y = Convert.ToInt32(split[1].Trim());

                output.Coords.Add(new Coordinate(id, x, y));
                id++;
            }

            return output;

        }

        public static void CalculateNearestCoords(ref Coordinates input)
        {

            Coordinate stoppingPoint = input.GetFurthestCoordinate();

            for (int i = 0; i < stoppingPoint.x; i++)
            {
                for (int j = 0; j < stoppingPoint.y; j++)
                {
                    int ID = 0;
                    int count = Int32.MaxValue;
                    foreach(Coordinate c in input.Coords)
                    {
                        
                        int distance = Math.Abs((i - c.x) + (j - c.y));
                        if(distance < count)
                        {
                            count = distance;
                            //ID = c.
                        }
                    }
                }
            }
        }

    }
}
