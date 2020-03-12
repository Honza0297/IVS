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
        public static long Add(long a, long b)
        {
            return a + b;
        }

        /**
         * @brief Adds two numbers
         *
         * @param a First number
         * @param b Second number
         * @return Returns the result of a + b
         */
        public static double Add(double a, double b)
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
        public static double Subtract(double minuend, double subtrahend)
        {
            return minuend - subtrahend;
        }

        /**
         * @brief Subtracts two numbers
         *
         * @param minuend 
         * @param subtrahend
         * @return Returns the result of minuend - subtrahend
         */
        public static long Subtract(long minuend, long subtrahend)
        {
            return minuend - subtrahend;
        }

        /**
         * @brief Multiplies two numbers
         *
         * @param a First number
         * @param b Second number
         * @return Returns the result of a * b
         */
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        /**
         * @brief Multiplies two numbers
         *
         * @param a First number
         * @param b Second number
         * @return Returns the result of a * b
         */
        public static long Multiply(long a, long b)
        {
            return a * b;
        }

        /**
         * @brief Divides two numbers
         *
         * @param dividend
         * @param divisor
         * @return Returns the result of a / b
         */
        public static double Divide(double dividend, double divisor)
        {
            if(divisor == 0)
                throw new MathLibException("Division by zero is not defined!");

            return dividend / divisor;
        }

        /**
         * @brief Calculates factorial of the given number
         *
         * @param number Number for factorial calculation
         * @return Returns the factorial of number (number!)
         */
        public static long Factorial(long number)
        {
            if(number < 0)
                throw new MathLibException("Factorial is defined only for zero and greater!");

            if (number == 0)
                return 1;

            return number * Factorial(number - 1);
        }

        /**
        * @brief Calculates power
        *
        * @param baseNumber Number which will be powered
        * @param power Value of power
        * @return Returns the result of baseNumber^power
        */
        public static double Power(double baseNumber, int power)
        {
            if(power <= 0)
                throw new MathLibException("The only supported powers are 1, 2, 3, ...");

            return Math.Pow(baseNumber, power);
        }

        /**
       * @brief Calculates root
       *
       * @param radicant
       * @param degree
       * @return Returns the root of radicand with the degree
       */
        public static double Root(double radicand, int degree)
        {   
            if(degree == 0)
                throw new MathLibException("Degree cannot be 0!");

            if(radicand < 0 && (degree % 2 == 0)) //radicant is negative and degree is even
                throw new MathLibException("Root is not defined for negative radicand when the degree is even!");
            else if (radicand < 0) //radicant is negative and degree is odd
                return -Math.Pow(-radicand, 1.0 / degree);

            return Math.Pow(radicand, 1.0 / degree);
        }

        /**
       * @brief Returns a number between 0 and 1 (zero included)
       *
       * @return Returns a number between 0 and 1 (zero included)
       */
        public static double Random()
        {
            int limit = 9999999;
            var random = new Random();
            int randomNumber = random.Next(limit);

            return randomNumber / ((double) limit + 1);
        }
    }
}