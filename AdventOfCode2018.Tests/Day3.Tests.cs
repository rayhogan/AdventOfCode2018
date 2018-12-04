using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;
using System.Collections.Generic;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Day3Part1()
        {
            // Arrange
            int result = 0;
            string[] input = Day2.ParseInput(@"..\..\..\Inputs\\Day3.txt");

            // Act
            List<string> coords = Day3.GenerateCoordinates(input);
            List<string> cleanedUp = Day3.RemoveNonDuplicates(coords);
            result = Day3.CountSquares(cleanedUp);

            // Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        public void Day3Part2()
        {
            // Arrange
            int result = 0;
            string[] input = Day2.ParseInput(@"..\..\..\Inputs\\Day3.txt");

            // Act
            List<string> coords = Day3.GenerateCoordinates(input);
            List<string> cleanedUp = Day3.RemoveNonDuplicates(coords);
            result = Day3.FindOutlier(input,cleanedUp);

            // Assert
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void Day3RemoveNonDuplicates()
        {
            // Arrange
            List<string> example = new List<string>() { "hello", "world", "Ray", "hello", "world" };
            List<string> expected = new List<string>() { "hello", "hello", "world", "world" };

            // Act
            List<string> cleanedUp = Day3.RemoveNonDuplicates(example);

            // Assert
            Assert.AreEqual(4, cleanedUp.Count);

        }

        public void Day3CountDistinctValues()
        {
            // Arrange
            List<string> example = new List<string>() { "hello", "world", "Ray", "hello", "world" };

            // Act
            int count = Day3.CountSquares(example);

            // Assert
            Assert.AreEqual(3, count);

        }
    }
}
