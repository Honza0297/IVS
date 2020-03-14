/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: MathLib.cs
 * Date: 11.3.2020
 * Author: Daniel Bubeníček (xbuben05@stud.fit.vutbr.cz)
 *
 * Description: Math library
 *
 *******************************************************************/
/**
 * @file MathLib.cs
 *
 * @brief Math library
 * @author Daniel Bubeníček (xbuben05)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IVSCalc.Entities;

namespace IVSCalc.MathLib
{
    /**
     * @class MathLib
     *
     * @brief Math library with static methods for operations used in calc
     */
    public static class MathLib
    {
        /**
         * @brief Adds two numbers
         *
         * @param a First number
         * @param b Second number
         * @return Returns the result of a + b
         */
        public static Operand Add(Operand a, Operand b)
        {
            return a + b;
        }

        /**
         * @brief Subtracts two numbers
         *
         * @param minuend 
         * @param subtrahend
         * @return Returns the result of minuend - subtrahend
         */
        public static Operand Subtract(Operand minuend, Operand subtrahend)
        {
            return minuend - subtrahend;
        }

        public static Operand Multiply(Operand a, Operand b)
        {
            return a * b;
        }

        public static Operand Divide(Operand dividend, Operand divisor)
        {
            if(divisor.DoubleOperand == 0)
                throw new MathLibException("Division by zero is not defined!");

            return dividend / divisor;
        }

        /**
         * @brief Calculates factorial of the given number
         *
         * @param number Number for factorial calculation
         * @return Returns the factorial of number (number!)
         */
        public static Operand Factorial(Operand number)
        {

            if (number.Type == TypeOfOperand.Double || number.LongOperand < 0)
                throw new MathLibException("Factorial is defined only for non-negative integers!");

            if (number.LongOperand == 0)
                return new Operand(1);

            return number * Factorial(number - new Operand(1));
        }

        /**
        * @brief Calculates power
        *
        * @param baseNumber Number which will be powered
        * @param power Value of power
        * @return Returns the result of baseNumber^power
        */
        public static Operand Power(Operand baseNumber, Operand power)
        {
            if(power.LongOperand <= 0)
                throw new MathLibException("The only supported powers are greater than zero integers!");

            return new Operand(Math.Pow(baseNumber.DoubleOperand, power.LongOperand));
        }

        /**
       * @brief Calculates root
       *
       * @param radicant
       * @param degree
       * @return Returns the root of radicand with the degree
       */
        public static Operand Root(Operand radicand, Operand degree)
        {   
            if(degree.LongOperand == 0)
                throw new MathLibException("Degree cannot be 0!");

            if(radicand.DoubleOperand < 0 && (degree.LongOperand % 2 == 0)) //radicant is negative and degree is even
                throw new MathLibException("Root is not defined for negative radicand when the degree is even!");
            else if (radicand.DoubleOperand < 0) //radicant is negative and degree is odd
                return new Operand(-Math.Pow(-radicand.DoubleOperand, 1.0 / degree.LongOperand));

            return new Operand(Math.Pow(radicand.DoubleOperand, 1.0 / degree.LongOperand));
        }

        /**
       * @brief Returns a number between 0 and 1 (zero included)
       *
       * @return Returns a number between 0 and 1 (zero included)
       */
        public static Operand Random()
        {
            int limit = 9999999;
            var random = new Random();
            int randomNumber = random.Next(limit);

            return new Operand(randomNumber / ((double) limit + 1));
        }
    }
}