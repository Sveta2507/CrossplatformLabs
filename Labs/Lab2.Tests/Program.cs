using System;
using System.IO;
using Lab2;
using Xunit;

namespace Lab2.Tests
{
    public class RailwayCostTests
    {
        private string GetInputFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), fileName); //директорія тестів
        }

        [Theory]
        [InlineData("test1.txt", 12)]
        [InlineData("test2.txt", 4)]
        [InlineData("test3.txt", 3)]
        [InlineData("test4.txt", 23)]
        [InlineData("test5.txt", 5)]
        public void CalculateMinimumCost_ShouldReturnExpectedResult(string inputFileName, int expectedOutput)
        {
            string inputFilePath = GetInputFilePath(inputFileName);
            int actualOutput = Program.CalculateMinimumCost(inputFilePath);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
