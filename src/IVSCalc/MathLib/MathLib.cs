using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVSCalc.MathLib
{
    public static class MathLib
    {
        public static long Add(long a, long b)
        {
            return a + b;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }


        public static double Subtract(double minuend, double subtrahend)
        {
            return minuend - subtrahend;
        }

        public static long Subtract(long minuend, long subtrahend)
        {
            return minuend - subtrahend;
        }


        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static long Multiply(long a, long b)
        {
            return a * b;
        }


        public static double Divide(double dividend, double divisor)
        {
            if(divisor == 0)
                throw new MathLibException("Division by zero is not defined!");

            return dividend / divisor;
        }

        public static long Factorial(long a)
        {
            if(a < 0)
                throw new MathLibException("Factorial is defined only for zero and greater!");

            if (a == 0)
                return 1;

            return a * Factorial(a - 1);
        }

        public static double Power(double baseNumber, int power)
        {
            if(power <= 0)
                throw new MathLibException("The only supported powers are 1, 2, 3, ...");

            return Math.Pow(baseNumber, power);
        }

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

        public static double Random()
        {
            int limit = 9999999;
            var random = new Random();
            int randomNumber = random.Next(limit);

            return randomNumber / ((double) limit + 1);
        }
    }
}