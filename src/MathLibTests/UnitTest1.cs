using System;
using IVSCalc.MathLib;
using Xunit;

namespace MathLibTests
{
    public class MathLibTests
    {
        private int a = 5;
        private int b = 8;
        private int c = -3;
        private double d = 4.7;
        private double e = 2.1;
        private double f = -4.1;
        private int zero = 0;
        
        [Fact]
        public void AdditionTest()
        {
            Assert.Equal(MathLib.Add(a, b), a + b);
            Assert.Equal(MathLib.Add(b, a), a + b);
            Assert.Equal(MathLib.Add(a, c), a + c);
            Assert.Equal(MathLib.Add(c, d), c + d);
            Assert.Equal(MathLib.Add(e, d), e + d);
            Assert.Equal(MathLib.Add(e, f), e + f);
            Assert.Equal(MathLib.Add(d, zero), d + zero);
        }

        [Fact]
        public void SubtractionTest()
        {
            Assert.Equal(MathLib.Subtract(a, b), a - b);
            //TODO Denny
        }

        [Fact]
        public void MultiplicationTest()
        {
            Assert.Equal(MathLib.Multiply(a, b), a * b);
            //TODO Denny
        }

        [Fact]
        public void DivisionTest()
        {
            Assert.Equal(MathLib.Divide(a, b), a / (double) b);
            //TODO Denny
        }

        [Fact]
        public void FactorialTest()
        {
            //Assert.Equal(MathLib.Factorial(a));
            //TODO Denny
        }

        [Fact]
        public void PowerTest()
        {
            //TODO Denny
            //Assert.Equal(MathLib.Power(a, b), );
        }

        [Fact]
        public void RootTest()
        {
            //Assert.Equal(MathLib.Root(a, b),);
            //TODO Denny
        }

        //TODO Denny 1 more math function test
    }
}
