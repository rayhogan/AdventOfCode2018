using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day1Tests
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

        [TestMethod]
        public void TestIntegerParsing()
        {
            // Arrange
            string value1 = "-34";
            string value2 = "+12";
            string value3 = "0";
            string value4 = "-1";

            // Act
            int parsed1 = Day1.ParseIntegerValue(value1);
            int parsed2 = Day1.ParseIntegerValue(value2);
            int parsed3 = Day1.ParseIntegerValue(value3);
            int parsed4 = Day1.ParseIntegerValue(value4);

            // Assert
            Assert.AreEqual(-34, parsed1);
            Assert.AreEqual(12, parsed2);
            Assert.AreEqual(0, parsed3);
            Assert.AreEqual(-1, parsed4);
        }
    }
}
