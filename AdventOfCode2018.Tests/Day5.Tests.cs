using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2018;
using System.Collections.Generic;
using System;
using AdventOfCode2018.Day4Stuff;

namespace AdventOfCode2018.Tests
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void Day5Part1()
        {
            // Arrange
            string input = Helper.ParseSingleLineInput(@"..\..\..\Inputs\\Day5.txt");

            // Act
            int polymerCount = Day5.PolymerCount(input);

            // Assert
            Assert.AreEqual(10, polymerCount);


        }

        [TestMethod]
        public void Day5PatternMatch()
        {

            Assert.AreEqual(true, Day5.PatternMatch('a', 'A'));
            Assert.AreEqual(true, Day5.PatternMatch('b', 'B'));
            Assert.AreEqual(true, Day5.PatternMatch('c', 'C'));
            Assert.AreEqual(true, Day5.PatternMatch('d', 'D'));
            Assert.AreEqual(true, Day5.PatternMatch('e', 'E'));
            Assert.AreEqual(true, Day5.PatternMatch('f', 'F'));
            Assert.AreEqual(true, Day5.PatternMatch('g', 'G'));
            Assert.AreEqual(true, Day5.PatternMatch('h', 'H'));
            Assert.AreEqual(true, Day5.PatternMatch('i', 'I'));
            Assert.AreEqual(true, Day5.PatternMatch('j', 'J'));
            Assert.AreEqual(true, Day5.PatternMatch('k', 'K'));
            Assert.AreEqual(true, Day5.PatternMatch('l', 'L'));
            Assert.AreEqual(true, Day5.PatternMatch('m', 'M'));
            Assert.AreEqual(true, Day5.PatternMatch('n', 'N'));
            Assert.AreEqual(true, Day5.PatternMatch('o', 'O'));
            Assert.AreEqual(true, Day5.PatternMatch('p', 'P'));
            Assert.AreEqual(true, Day5.PatternMatch('q', 'Q'));
            Assert.AreEqual(true, Day5.PatternMatch('r', 'R'));
            Assert.AreEqual(true, Day5.PatternMatch('s', 'S'));
            Assert.AreEqual(true, Day5.PatternMatch('t', 'T'));
            Assert.AreEqual(true, Day5.PatternMatch('u', 'U'));
            Assert.AreEqual(true, Day5.PatternMatch('v', 'V'));
            Assert.AreEqual(true, Day5.PatternMatch('w', 'W'));
            Assert.AreEqual(true, Day5.PatternMatch('x', 'X'));
            Assert.AreEqual(true, Day5.PatternMatch('y', 'Y'));
            Assert.AreEqual(true, Day5.PatternMatch('z', 'Z'));

            Assert.AreEqual(true, Day5.PatternMatch('A', 'a'));
            Assert.AreEqual(true, Day5.PatternMatch('B', 'b'));
            Assert.AreEqual(true, Day5.PatternMatch('C', 'c'));
            Assert.AreEqual(true, Day5.PatternMatch('D', 'd'));
            Assert.AreEqual(true, Day5.PatternMatch('E', 'e'));
            Assert.AreEqual(true, Day5.PatternMatch('F', 'f'));
            Assert.AreEqual(true, Day5.PatternMatch('G', 'g'));
            Assert.AreEqual(true, Day5.PatternMatch('H', 'h'));
            Assert.AreEqual(true, Day5.PatternMatch('I', 'i'));
            Assert.AreEqual(true, Day5.PatternMatch('J', 'j'));
            Assert.AreEqual(true, Day5.PatternMatch('K', 'k'));
            Assert.AreEqual(true, Day5.PatternMatch('L', 'l'));
            Assert.AreEqual(true, Day5.PatternMatch('M', 'm'));
            Assert.AreEqual(true, Day5.PatternMatch('N', 'n'));
            Assert.AreEqual(true, Day5.PatternMatch('O', 'o'));
            Assert.AreEqual(true, Day5.PatternMatch('P', 'p'));
            Assert.AreEqual(true, Day5.PatternMatch('Q', 'q'));
            Assert.AreEqual(true, Day5.PatternMatch('R', 'r'));
            Assert.AreEqual(true, Day5.PatternMatch('S', 's'));
            Assert.AreEqual(true, Day5.PatternMatch('T', 't'));
            Assert.AreEqual(true, Day5.PatternMatch('U', 'u'));
            Assert.AreEqual(true, Day5.PatternMatch('V', 'v'));
            Assert.AreEqual(true, Day5.PatternMatch('W', 'w'));
            Assert.AreEqual(true, Day5.PatternMatch('X', 'x'));
            Assert.AreEqual(true, Day5.PatternMatch('Y', 'y'));
            Assert.AreEqual(true, Day5.PatternMatch('Z', 'z'));

            Assert.AreEqual(false, Day5.PatternMatch('a', 'a'));


        }


    }
}
