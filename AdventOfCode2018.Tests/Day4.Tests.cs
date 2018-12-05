using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;
using System.Collections.Generic;
using System;
using AdventOfCode2018.Day4Stuff;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day4Tests
    {
        [TestMethod]
        public void Day4Part1()
        {
            // Arrange
            string[] input = Day2.ParseInput(@"..\..\..\Inputs\\Day4.txt");

            // Act
            Dictionary<DateTime, string> sorted = Day4.ParseInstructions(input);
            Dictionary<int,Guard> guards = Day4.CreateDataStructure(sorted);
            int longestSleeper = Day4.FindLongestSleeper(guards);
            int sleepiestMinute = guards[longestSleeper].FindMostSleepyMinute();

            // Assert
            Assert.AreEqual(10, longestSleeper);
            Assert.AreEqual(24, sleepiestMinute);
            Assert.AreEqual(240, (sleepiestMinute*longestSleeper));

        }

        [TestMethod]
        public void Day4Part2()
        {
            // Arrange
            string[] input = Day2.ParseInput(@"..\..\..\Inputs\\Day4.txt");

            // Act
            Dictionary<DateTime, string> sorted = Day4.ParseInstructions(input);
            Dictionary<int, Guard> guards = Day4.CreateDataStructure(sorted);
            int[,] longestMinuteSleeper = Day4.FindMostSleptMinute(guards);

            // Assert
            Assert.AreEqual(99, longestMinuteSleeper[0,0]);
            Assert.AreEqual(45, longestMinuteSleeper[0, 1]);
            Assert.AreEqual(4455, (longestMinuteSleeper[0, 0] * longestMinuteSleeper[0, 1]));


        }


    }
}
