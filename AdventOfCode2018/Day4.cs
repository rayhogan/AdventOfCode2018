using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using AdventOfCode2018.Day4Stuff;

namespace AdventOfCode2018
{
    public static class Day4
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day4.txt");

            Part1(input);
            Part2(input);
        }

        private static void Part1(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part I");
            Console.ForegroundColor = ConsoleColor.White;

            Dictionary<DateTime, string> sorted = ParseInstructions(input);
            Dictionary<int, Guard> guards = CreateDataStructure(sorted);
            int longestSleeper = FindLongestSleeper(guards);
            int longestMinute = guards[longestSleeper].FindMostSleepyMinute();

            Console.WriteLine("Guard ID: " + longestSleeper + " Sleepy Minute: " + longestMinute);
            Console.WriteLine("Result: " + (longestMinute * longestSleeper));
        }

        private static void Part2(string[] input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Part II");
            Console.ForegroundColor = ConsoleColor.White;

            Dictionary<DateTime, string> sorted = ParseInstructions(input);
            Dictionary<int, Guard> guards = CreateDataStructure(sorted);
            int[,] longestMinuteSleeper = FindMostSleptMinute(guards);

            Console.WriteLine("Guard ID: " + longestMinuteSleeper[0, 0] + " Sleepy Minute: " + longestMinuteSleeper[0, 1]);
            Console.WriteLine("Result: " + (longestMinuteSleeper[0, 0] * longestMinuteSleeper[0, 1]));

        }

        public static Dictionary<DateTime, String> ParseInstructions(string[] input)
        {
            Dictionary<DateTime, String> sorted = new Dictionary<DateTime, string>();

            foreach (string s in input)
            {
                string time = Helper.Between(s, "[", "]");
                string actionText = s.Split("]")[1];
                sorted.Add(DateTime.ParseExact(time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), actionText);
            }

            return sorted;
        }

        public static Dictionary<int, Guard> CreateDataStructure(Dictionary<DateTime, String> instructions)
        {
            Dictionary<int, Guard> guards = new Dictionary<int, Guard>();
            int guardId = 0;
            foreach (KeyValuePair<DateTime, String> pair in instructions.OrderBy(p => p.Key))
            {

                if (pair.Value.Trim().StartsWith("Guard"))
                {

                    int id = Int32.Parse(pair.Value.Split(" ")[2].TrimStart('#'));

                    if (guards.ContainsKey(id))
                    {
                        Day4Stuff.Action action = new Day4Stuff.Action(pair.Key, ActionType.Starts);
                        guards[id].AddAction(action);
                    }
                    else
                    {
                        Guard currentGuard = new Guard(id);
                        Day4Stuff.Action action = new Day4Stuff.Action(pair.Key, ActionType.Starts);
                        currentGuard.AddAction(action);

                        guards.Add(id, currentGuard);

                    }
                    guardId = id;

                }
                else if (pair.Value.Trim().StartsWith("falls"))
                {
                    Day4Stuff.Action action = new Day4Stuff.Action(pair.Key, ActionType.Sleeps);
                    guards[guardId].AddAction(action);
                }
                else if (pair.Value.Trim().StartsWith("wakes"))
                {
                    Day4Stuff.Action action = new Day4Stuff.Action(pair.Key, ActionType.Wakes);
                    guards[guardId].AddAction(action);
                }
                else
                {
                    throw new Exception("Error creating data structure");
                }
            }

            return guards;
        }

        public static int FindLongestSleeper(Dictionary<int, Guard> input)
        {
            int guardID = 0;
            double sleepingTime = 0.0;

            foreach (KeyValuePair<int, Guard> guard in input)
            {
                double result = guard.Value.CalculateMinutesSleeping();

                if (result > sleepingTime)
                {
                    sleepingTime = result;
                    guardID = guard.Key;
                }
            }

            return guardID;
        }

        public static int[,] FindMostSleptMinute(Dictionary<int, Guard> input)
        {
            int[,] result = new int[,] { { 0, 0 } };
            int guardID = 0;
            int sleepyMinute = 0;
            int timesSlept = 0;

            foreach (KeyValuePair<int, Guard> guard in input)
            {
                int minute = guard.Value.FindMostSleepyMinute();

                if (minute != 0)
                {

                    int numberOfTimes = guard.Value.HowManyTimesMinuteSlept(minute);

                    if (numberOfTimes >= timesSlept)
                    {
                        Console.WriteLine("Slept Minute: " + minute + " For this number: " + numberOfTimes);
                        sleepyMinute = minute;
                        guardID = guard.Key;
                        timesSlept = numberOfTimes;
                    }
                }
            }

            result[0, 0] = guardID;
            result[0, 1] = sleepyMinute;

            return result;
        }


    }
}
