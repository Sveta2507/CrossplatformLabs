using System;
using Xunit;
using Lab1;

namespace Lab1.Tests
{
    public class PrimeDivisorsTests
    {
        [Fact]
        public void TestDivisors_1()
        {
            long input = 1;
            string output = "1";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_2()
        {
            long input = 2;
            string output = "2";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_12()
        {
            long input = 12;
            string output = "6";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_239()
        {
            long input = 239;
            string output = "2";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_1019()
        {
            long input = 1019;
            string output = "число завелике";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }
    }
}
