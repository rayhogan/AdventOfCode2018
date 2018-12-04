using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Day3
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day3.txt");

            Part1(input);
            Part2(input);
        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            List<string> coords = GenerateCoordinates(input);
            List<string> cleanedUp = RemoveNonDuplicates(coords);
            int result = CountSquares(cleanedUp);

            Console.WriteLine("Square Meters: "+ result);
        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            List<string> coords = GenerateCoordinates(input);
            List<string> cleanedUp = RemoveNonDuplicates(coords);
            int result = FindOutlier(input, cleanedUp);

            Console.WriteLine("Outlier ID: "+ result);
        }

        public static List<string> GenerateCoordinates(string[] input)
        {
            List<string> output = new List<string>();

            // example: #1 @ 1,3: 4x4

            foreach (string s in input)
            {
                string[] split = s.Split(" ");  // Split the input string
                int x = Int32.Parse(split[2].TrimEnd(':').Split(",")[0]); // Etxratc x value
                int y = Int32.Parse(split[2].TrimEnd(':').Split(",")[1]); // Extract y valur

                int xCount = Int32.Parse(split[3].Split("x")[0]); // Extract size of 
                int yCount = Int32.Parse(split[3].Split("x")[1]); // the square

                // Loop through and store co-ordindates as List of strings
                for (int i = 0; i < xCount; i++)
                {
                    for (int j = 0; j < yCount; j++)
                    {
                        output.Add((x + i) + "x" + (y + j));
                    }
                }
            }

            return output;
        }

        public static List<string> RemoveNonDuplicates(List<string> input)
        {
            // Remove the non-duplicates from the list
            var resultList = input.GroupBy(x => x)
                     .Where(g => g.Count() > 1)
                     .SelectMany(g => g)
                     .ToList();

            return resultList;
        }

        public static int CountSquares(List<string> input)
        {
            // Count the distinct values of the list
            int res = (from x in input select x).Distinct().Count();

            return res;
        }

        public static int FindOutlier(string[] input, List<string> cleanedInput)
        {
            int outlierID = 1;
            // Loop through the input
            foreach (string s in input)
            {
                bool foundOutlier = true;
                string[] split = s.Split(" ");
                int x = Int32.Parse(split[2].TrimEnd(':').Split(",")[0]);
                int y = Int32.Parse(split[2].TrimEnd(':').Split(",")[1]);

                int xCount = Int32.Parse(split[3].Split("x")[0]);
                int yCount = Int32.Parse(split[3].Split("x")[1]);

                for (int i = 0; i < xCount; i++)
                {
                    for (int j = 0; j < yCount; j++)
                    {
                        // If co-ordinate is listed in the cleaned up input, then we know it's not
                        // a valid outlier. So we may break and look at the next
                        if (cleanedInput.Contains((x + i) + "x" + (y + j)))
                        {
                            foundOutlier = false;
                            i = xCount;
                            break;
                        }
                    }
                }

                if(foundOutlier)
                {
                    // Outlier found - :)!
                    break;
                }

                outlierID++;

            }

            return outlierID;
        }
    }
}
