using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public static class Day1
    {
        public static void Run()
        {
            string[] input = ParseInput(@"Inputs\\Day1.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            int frequency = CalcFrequency(input);

            Console.WriteLine("Frequency: " + frequency);
        }

        public static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            int repeating = CalcRepeatingFrequency(input);

            Console.WriteLine("Repeating Frequency: " + repeating);
        }

        public static string[] ParseInput(string location)
        {
            string[] input = System.IO.File.ReadAllLines(location);

            return input;
        }

        public static int CalcFrequency(string[] input)
        {
            int freq = 0;

            foreach (string s in input)
            {
                freq += ParseIntegerValue(s);
            }

            return freq;
        }

        public static int ParseIntegerValue(string input)
        {
            int value = Int32.Parse(input, System.Globalization.NumberStyles.AllowLeadingSign);
            return value;
        }

        public static int CalcRepeatingFrequency(string[] input)
        {
            int result = 0;
            bool searching = true;
            List<int> frequencies = new List<int>();

            do
            {
                foreach (string s in input)
                {
                    result += ParseIntegerValue(s);

                    if (frequencies.Contains(result))
                    {
                        searching = false;
                        break;
                    }
                    else
                        frequencies.Add(result);
                }

            } while (searching);


            return result;

        }
    }
}
