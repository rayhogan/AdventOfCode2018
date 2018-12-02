using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Day2Part1()
        {
            // Arrange
            int checkSum = 0;
            string[] input = Day2.ParseInput(@"..\..\..\Inputs\\Day2.txt");

            // Act
            checkSum = Day2.CheckSumCounter(input);

            // Assert
            Assert.AreEqual(checkSum, 12);
        }

        [TestMethod]
        public void Day2Part2()
        {
            // Arrange
            string[] input = Day2.ParseInput(@"..\..\..\Inputs\\Day2-2.txt");

            // Act
            string commonLetters = Day2.DetermineCommonLetters(input);

            // Assert
            Assert.AreEqual(commonLetters, "fgij");
        }

    }
}
