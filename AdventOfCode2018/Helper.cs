using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018
{
    public static class Helper
    {
        public static string[] ParseInput(string location)
        {
            string[] input = System.IO.File.ReadAllLines(location);

            return input;
        }

        public static string ParseSingleLineInput(string location)
        {
            string input = System.IO.File.ReadAllText(location);

            return input;
        }

        public static string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}
