using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using AdventOfCode2018.Day4Stuff;

namespace AdventOfCode2018
{
    public static class Day5
    {
        public static void Run()
        {
            string input = Helper.ParseSingleLineInput(@"Inputs\\Day5.txt");
            
            Part1(input);
            Part2(input);
        }

        private static void Part1(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            int polymerCount = PolymerCount(input);

            Console.WriteLine("Polymer: " + polymerCount);

        }

        private static void Part2(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            List<int> results = new List<int>();
            foreach(char c in alphabet)
            {
                string cleansedString = input.Replace(c.ToString(), string.Empty);

                cleansedString = cleansedString.Replace(char.ToUpper(c).ToString(), string.Empty);
                results.Add(PolymerCount(cleansedString));
            }

            int minimum = results.Min();
            Console.WriteLine("Shortest Polymer: " + alphabet[results.IndexOf(minimum)] + " Count: " + minimum);

        }

        public static int PolymerCount(string input)
        {
            int changes = 0;
            bool computing = true;

            char[] inputArray = input.ToCharArray();

            do
            {
                computing = false;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if ((i + 1) < input.Length && input[i] != '_')
                    {

                        int comparisonIndex = i + 1;

                        bool lookinForNextValue = true;

                        do
                        {
                            if (inputArray[comparisonIndex] != '_')
                            {
                                lookinForNextValue = false;

                                if (PatternMatch(inputArray[i], inputArray[comparisonIndex]))
                                {
                                    // Match
                                    inputArray[i] = '_';
                                    inputArray[comparisonIndex] = '_';
                                    changes += 2;
                                    computing = true;

                                }

                                i = (comparisonIndex - 1);

                            }
                            else if ((comparisonIndex + 1) >= input.Length)
                            {
                                lookinForNextValue = false;
                            }
                            else
                                comparisonIndex++;
                        }
                        while (lookinForNextValue);


                    }
                }
            }
            while (computing);

            return (input.Length - changes);
        }

        public static bool PatternMatch(char a, char b)
        {
            if ((char.IsUpper(a) && char.IsLower(b)) || (char.IsLower(a) && char.IsUpper(b)))
            {
                if (char.ToLower(a) == char.ToLower(b))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
