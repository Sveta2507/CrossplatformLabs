using System.Collections.Generic;
using Xunit;

namespace Lab3.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_EscapePossible_SimpleCase()
        {
            int N = 4;
            int M = 5;
            int startX = 1;
            int startY = 0;
            int[,] basePlan = {
                { 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };
            Dictionary<(int, int), (int, int)> tunnels = new()
            {
                { (0, 1), (0, 3) },
                { (2, 0), (0, 3) }
            };
            List<(int, int)> exits = new() { (1, 3) };

            int result = Program.BFS(startX, startY, basePlan, tunnels, exits);

            Assert.Equal(4, result);
        }

        [Fact]
        public void Test_NoEscape_Possible()
        {
            int N = 3;
            int M = 3;
            int startX = 0;
            int startY = 0;
            int[,] basePlan = {
                { 0, 1, 0 },
                { 1, 1, 0 },
                { 0, 0, 0 }
            };
            Dictionary<(int, int), (int, int)> tunnels = new();
            List<(int, int)> exits = new() { (2, 2) };

            int result = Program.BFS(startX, startY, basePlan, tunnels, exits);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void Test_ImpossibleEscape()
        {
            int N = 4;
            int M = 4;
            int startX = 0;
            int startY = 0;
            int[,] basePlan = {
                { 0, 1, 1, 1 },
                { 1, 1, 1, 1 },
                { 1, 1, 1, 0 },
                { 0, 0, 0, 0 }
            };
            Dictionary<(int, int), (int, int)> tunnels = new();
            List<(int, int)> exits = new() { (3, 3) };

            int result = Program.BFS(startX, startY, basePlan, tunnels, exits);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void Test_WithTunnels()
        {
            int N = 5;
            int M = 5;
            int startX = 0;
            int startY = 0;
            int[,] basePlan = {
                { 0, 0, 1, 0, 0 },
                { 0, 1, 1, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 0 }
            };
            Dictionary<(int, int), (int, int)> tunnels = new()
            {
                { (2, 2), (4, 0) }
            };
            List<(int, int)> exits = new() { (4, 4) };

            int result = Program.BFS(startX, startY, basePlan, tunnels, exits);

            Assert.Equal(9, result);
        }

        [Fact]
        public void Test_SimpleTunnelAndExit()
        {
            int N = 4;
            int M = 4;
            int startX = 0;
            int startY = 0;
            int[,] basePlan = {
                { 0, 0, 1, 0 },
                { 1, 0, 1, 0 },
                { 1, 0, 0, 0 },
                { 1, 1, 1, 0 }
            };
            Dictionary<(int, int), (int, int)> tunnels = new()
            {
                { (2, 1), (3, 3) }
            };
            List<(int, int)> exits = new() { (3, 3) };

            int result = Program.BFS(startX, startY, basePlan, tunnels, exits);

            Assert.Equal(5, result);
        }
    }
}
