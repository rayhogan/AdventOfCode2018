using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Day1CalculationsPart1()
        {
            // Arrange
            int total = 0;
            string[] input = Day1.ParseInput(@"..\..\..\Inputs\\Day1.txt");

            // Act
            total = Day1.CalcFrequency(input);

            // Assert
            Assert.AreEqual(3, total);
        }

        [TestMethod]
        public void Day1CalculationsPart2()
        {
            // Arrange
            int freq = 0;
            string[] input = Day1.ParseInput(@"..\..\..\Inputs\\Day1.txt");

            // Act
            freq = Day1.CalcRepeatingFrequency(input);

            // Assert
            Assert.AreEqual(2, freq);
        }
    }
}
