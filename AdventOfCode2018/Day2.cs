using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018
{
    public static class Day2
    {
        public static void Run()
        {
            string[] input = ParseInput(@"Inputs\\Day2.txt");
            Part1(input);
            Part2(input);
        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            int checkSum = CheckSumCounter(input);

            Console.WriteLine("Check Sum: " + checkSum);
        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            string commonLetters = DetermineCommonLetters(input);

            Console.WriteLine("Common Letters: " + commonLetters);
        }

        public static string[] ParseInput(string location)
        {
            string[] input = System.IO.File.ReadAllLines(location);

            return input;
        }

        public static int CheckSumCounter(string[] input)
        {
            // Counters for when we find 2 or 3 repeating letters
            int twos = 0;
            int threes = 0;

            // Loop through the input
            foreach(string s in input)
            {
                // Split word
                char[] split = s.ToCharArray();
                // log when we find repeating variations
                bool found2 = false;
                bool found3 = false;

                // Loop through the characters
                foreach(char character in split)
                {
                    // Get the repetitions
                    var count = s.Count(x => x == character);

                    // If we find 2 or 3 repeating chars
                    if (count == 2 && !found2)
                    {
                        twos++;
                        found2 = true;
                    }
                    else if (count == 3 && !found3)
                    {
                        threes++;
                        found3 = true;
                    }

                    // If we've found both, then break out early
                    if (found2 && found3)
                        break;

                }
            }

            // Return checksum
            return twos * threes;
        }

        public static string DetermineCommonLetters(string[] input)
        {
            // Store final result in a string
            string result = "";

            // Loop through input
            foreach (string s in input)
            {
                
                // Compare each word to the rest of the list
                foreach(string sc in input)
                {
                    if(s != sc) // Ignore if we're comparing against ourselvess
                    {
                        // Split words in character arrays
                        char[] split1 = s.ToCharArray();
                        char[] split2 = sc.ToCharArray();

                        StringBuilder sb = new StringBuilder();
                        int counter = 0;

                        // Compare each letter
                        for(int i=0;i<split1.Count();i++)
                        {
                            if(split1[i] == split2[i])
                            {
                                sb.Append(split1[i]); // Append to string builder if a match
                            }
                            else
                            {
                                counter++; // if not, log as mismatch
                            }

                            // If more than 1 mismatch then break out
                            if (counter > 1)
                                break;
                        }

                        // If we've found a word that has only 1 variation, then break out
                        if (counter == 1)
                        {
                            
                            result = sb.ToString();
                            break;
                        }
                    }
                }

                // If string is not empty, then we know we've found our match & can break out early
                if (result != string.Empty)
                    break;
            }

            return result;
        }
    }
}
