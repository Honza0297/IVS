/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: UnitTests.cs
 * Date: 11.3.2020
 * Authors: Daniel Bubeníèek (xbuben05@stud.fit.vutbr.cz), Jan Beran (xberan43@stud.fit.vutbr.cz)
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
using MathLibrary;
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
        private Operand a = new Operand(5);
        private Operand b = new Operand(8);
        private Operand c = new Operand(-3);
        private Operand d = new Operand(4.7);
        private Operand e = new Operand(2.1);
        private Operand f = new Operand(-4.1);
        private Operand zero = new Operand(0);

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
            Assert.Equal(MathLib.Divide(a, b), a / b);
            Assert.Equal(MathLib.Divide(a, c), a / c);
            Assert.Equal(MathLib.Divide(b, a), b / a);
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
            Assert.Equal(1, MathLib.Factorial(new Operand(0)).LongOperand);
            Assert.Equal(1, MathLib.Factorial(new Operand(1)).LongOperand);
            Assert.Equal(2, MathLib.Factorial(new Operand(2)).LongOperand);
            Assert.Equal(6, MathLib.Factorial(new Operand(3)).LongOperand);
            Assert.Equal(120, MathLib.Factorial(new Operand(5)).LongOperand);
            Assert.Throws<MathLibException>(() => MathLib.Factorial(new Operand(-1)));
            Assert.Throws<MathLibException>(() => MathLib.Factorial(new Operand(-42)));
        }

        /**
         * @brief Tests the Power() method of MathLib
         */
        [Fact]
        public void PowerTest()
        {
            Assert.Equal(4, MathLib.Power(new Operand(2), new Operand(2)).LongOperand);
            Assert.Equal(0, MathLib.Power(new Operand(0), new Operand(2)).LongOperand);
            Assert.Equal(1, MathLib.Power(new Operand(1), new Operand(2)).LongOperand);
            Assert.Equal(-1, MathLib.Power(new Operand(-1), new Operand(3)).LongOperand);
            Assert.Equal(16, MathLib.Power(new Operand(2), new Operand(4)).LongOperand);
            Assert.Equal(16, MathLib.Power(new Operand(-2), new Operand(4)).LongOperand);
            Assert.Equal(Math.Pow(2.3, 3), MathLib.Power(new Operand(2.3), new Operand(3)).DoubleOperand);
            Assert.Equal(Math.Pow(-5.9, 7), MathLib.Power(new Operand(-5.9), new Operand(7)).DoubleOperand);
            Assert.Throws<MathLibException>(() => MathLib.Power(new Operand(1), new Operand(0)));
            Assert.Throws<MathLibException>(() => MathLib.Power(new Operand(-5), new Operand(-1)));
            Assert.Throws<MathLibException>(() => MathLib.Power(new Operand(10), new Operand(-42)));
        }

        /**
         * @brief Tests the Root() method of MathLib
         */
        [Fact]
        public void RootTest()
        {
            Assert.Equal(0,  MathLib.Root(new Operand(0), new Operand(4)).LongOperand);
            Assert.Equal(-3, MathLib.Root(new Operand(-27), new Operand(3)).LongOperand);
            Assert.Equal(0, MathLib.Root(new Operand(0), new Operand(19)).LongOperand);
            Assert.Equal(2, MathLib.Root(new Operand(4), new Operand(2)).LongOperand);

            Assert.Equal(Math.Pow(3.46, 1 / (double) 4),  MathLib.Root(new Operand(3.46), new Operand(4)).DoubleOperand);
            Assert.Equal(-Math.Pow(83.2, 1 / (double) 5),  MathLib.Root(new Operand(-83.2), new Operand(5)).DoubleOperand);
            Assert.Equal(0.2,  MathLib.Root(new Operand( 5), new Operand(-1)).DoubleOperand);
            Assert.Throws<MathLibException>(() => MathLib.Root(new Operand( 5), new Operand(0)));
            Assert.Throws<MathLibException>(() => MathLib.Root(new Operand(-1), new Operand(2)));
            Assert.Throws<MathLibException>(() => MathLib.Root(new Operand(-52.36), new Operand(4)));
        }

        /**
         * @brief Tests the Random() method of MathLib
         */
        [Fact]
        public void RandomTest()
        {
            Operand[] randoms = new Operand[100];
            bool difference = false; //flag for check if at least 1 generated random number is different than the rest of the batch

            for (var i = 0; i < randoms.Length; i++)
            {
                randoms[i] = MathLib.Random();
            }

            foreach (var randomNumber in randoms)
            {
                if (randomNumber != randoms[0])
                    difference = true;

                Assert.True(randomNumber.LongOperand >= 0 && randomNumber.LongOperand < 1);
            }

            Assert.True(difference); //theoretically could fail, but it just won't
        }
    }
}
