/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: UnitTests.cs
 * Date: 11.3.2020
 * Author: Daniel Bubeníèek (xbuben05@stud.fit.vutbr.cz)
 *
 * Description: Unit tests for MathLib
 *
 *******************************************************************/
/**
 * @file UnitTests.cs
 *
 * @brief Unit tests for MathLib
 * @author Daniel Bubeníèek (xbuben05)
 */


using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using IVSCalc.MathLib;
using Xunit;

namespace MathLibTests
{
    /**
     * @class MathLibTests
     *
     * @brief Tests for MathLib
     */
    public class MathLibTests
    {
        private int a = 5;
        private int b = 8;
        private int c = -3;
        private double d = 4.7;
        private double e = 2.1;
        private double f = -4.1;
        private int zero = 0;

        /**
         * @brief Tests the Add() method of MathLib
         */
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

        /**
         * @brief Tests the Subtract() method of MathLib
         */
        [Fact]
        public void SubtractionTest()
        {
            Assert.Equal(MathLib.Subtract(a, b), a - b);
            Assert.Equal(MathLib.Subtract(a, c), a - c);
            Assert.Equal(MathLib.Subtract(a, d), a - d);
            Assert.Equal(MathLib.Subtract(d,e), d- e);
            Assert.Equal(MathLib.Subtract(d, f), d - f);
            Assert.Equal(MathLib.Subtract(zero, f), zero - f);
            Assert.Equal(MathLib.Subtract(e, zero), e - zero);
        }

        /**
         * @brief Tests the Multiply() method of MathLib
         */
        [Fact]
        public void MultiplicationTest()
        {
            Assert.Equal(MathLib.Multiply(a, b), a * b);
            Assert.Equal(MathLib.Multiply(b, a), a * b);
            Assert.Equal(MathLib.Multiply(a, c), a * c);
            Assert.Equal(MathLib.Multiply(a, d), a * d);
            Assert.Equal(MathLib.Multiply(c, e), c * e);
            Assert.Equal(MathLib.Multiply(d, e), d * e);
            Assert.Equal(MathLib.Multiply(e, f), f * e);
            Assert.Equal(MathLib.Multiply(f, zero), f * zero);
            Assert.Equal(MathLib.Multiply(b, zero), b * zero);
            Assert.Equal(MathLib.Multiply(f, f), f * f);
        }

        /**
         * @brief Tests the Divide() method of MathLib
         */
        [Fact]
        public void DivisionTest()
        {
            Assert.Equal(MathLib.Divide(a, b), a / (double)b);
            Assert.Equal(MathLib.Divide(a, c), a / (double)c);
            Assert.Equal(MathLib.Divide(b, a), b / (double)a);
            Assert.Equal(MathLib.Divide(d, e), d / e);
            Assert.Equal(MathLib.Divide(e, f), e / f);
            Assert.Equal(MathLib.Divide(f, d), f / d);
            Assert.Throws<MathLibException>(() => MathLib.Divide(a, zero));
            Assert.Throws<MathLibException>(() => MathLib.Divide(f, zero));
            Assert.Throws<MathLibException>(() => MathLib.Divide(zero, zero));
        }

        /**
         * @brief Tests the Factorial() method of MathLib
         */
        [Fact]
        public void FactorialTest()
        {
            Assert.Equal(1, MathLib.Factorial(0));
            Assert.Equal(1, MathLib.Factorial(1));
            Assert.Equal(2, MathLib.Factorial(2));
            Assert.Equal(6, MathLib.Factorial(3));
            Assert.Equal(120, MathLib.Factorial(5));
            Assert.Throws<MathLibException>(() => MathLib.Factorial(-1));
            Assert.Throws<MathLibException>(() => MathLib.Factorial(-42));
        }

        /**
         * @brief Tests the Power() method of MathLib
         */
        [Fact]
        public void PowerTest()
        {
            Assert.Equal(4, MathLib.Power(2, 2));
            Assert.Equal(0, MathLib.Power(0, 2));
            Assert.Equal(1, MathLib.Power(-1, 2));
            Assert.Equal(-1, MathLib.Power(-1, 3));
            Assert.Equal(16, MathLib.Power(2, 4));
            Assert.Equal(16, MathLib.Power(-2, 4));
            Assert.Equal(Math.Pow(2.3, 3), MathLib.Power(2.3, 3));
            Assert.Equal(Math.Pow(-5.9, 7), MathLib.Power(-5.9, 7));
            Assert.Throws<MathLibException>(() => MathLib.Power(1, 0));
            Assert.Throws<MathLibException>(() => MathLib.Power(-5, -1));
            Assert.Throws<MathLibException>(() => MathLib.Power(10, -42));
        }

        /**
         * @brief Tests the Root() method of MathLib
         */
        [Fact]
        public void RootTest()
        {
            Assert.Equal(0,  MathLib.Root(0, 4));
            Assert.Equal(0,  MathLib.Root(0, 19));
            Assert.Equal(2,  MathLib.Root(4, 2));
            Assert.Equal(-3,  MathLib.Root(-27, 3));
            Assert.Equal(Math.Pow(3.46, 1 / (double) 4),  MathLib.Root(3.46, 4));
            Assert.Equal(-Math.Pow(83.2, 1 / (double) 5),  MathLib.Root(-83.2, 5));
            Assert.Equal(0.2,  MathLib.Root(5, -1));
            Assert.Throws<MathLibException>(() => MathLib.Root(5, 0));
            Assert.Throws<MathLibException>(() => MathLib.Root(-1, 2));
            Assert.Throws<MathLibException>(() => MathLib.Root(-52.36, 4));
        }

        /**
         * @brief Tests the Random() method of MathLib
         */
        [Fact]
        public void RandomTest()
        {
            double[] randoms = new double[100];
            bool difference = false; //flag for check if at least 1 generated random number is different than the rest of the batch

            for (var i = 0; i < randoms.Length; i++)
            {
                randoms[i] = MathLib.Random();
            }

            foreach (var randomNumber in randoms)
            {
                if (randomNumber != randoms[0])
                    difference = true;

                Assert.True(randomNumber >= 0 && randomNumber < 1);
            }

            Assert.True(difference); //theoretically could fail, but it just won't
        }
    }
}
