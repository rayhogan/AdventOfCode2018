using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;
using System.Collections.Generic;
using System;
using AdventOfCode2018.Day6Stuff;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void Day6Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"..\..\..\Inputs\\Day6.txt");

            // Act
            CoordinateManager data = Day6.CreateDataStructure(input, 30);
            data.CalculateNearestCoordsAndSafePlaces();
            int largestArea = data.CalculateLargestArea();


            // Assert
            Assert.AreEqual(17, largestArea);

        }

        [TestMethod]
        public void Day6Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"..\..\..\Inputs\\Day6.txt");

            // Act
            CoordinateManager data = Day6.CreateDataStructure(input, 32);
            data.CalculateNearestCoordsAndSafePlaces();

            // Assert
            Assert.AreEqual(16, data.SafeLocations);

        }

    }
}
