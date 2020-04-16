/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: StandardDeviation.cs
 * Date: 11.3.2020
 * Author: Daniel Bubeníček (xbuben05@stud.fit.vutbr.cz) & Jan Beran (xbuben05@stud.fit.vutbr.cz)
 *
 * Description: App for standard deviation calculation - for profiling test
 *
 *******************************************************************/

/**
 * @file StandardDeviation.cs
 *
 * @brief App for standard deviation calculation
 * @author Daniel Bubeníček (xbuben05)
 * @author Jan Beran (xberan43)
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace stddev
{
    /**
     * @class StandardDeviation
     *
     * @brief App for standard deviation calculation
     */
    public class StandardDeviation
    {
        /**
         * @brief Calculates standard deviation of numbers from standard input and writes the result to standard output
         *
         * @param args not used
         */
        private static void Main(string[] args)
        {
            List<int> inputNumbers = new List<int>();

            try
            {
                while (true) //reading numbers until exception (end of file or other)
                    inputNumbers.Add(ReadNumber());
            }
            catch (EndOfStreamException) //all numbers have been read
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (inputNumbers.Count == 0) //no input numbers
                return;


            var s = CalculateStandardDeviation(inputNumbers);

            Console.WriteLine(s.ToString());
        }

        /**
         * @brief Calculates standard deviation from list of numbers
         *
         * @param inputNumbers
         * @return result of standard deviation
         */
        public static Operand CalculateStandardDeviation(IReadOnlyCollection<int> inputNumbers)
        {
            var sum = new Operand(0); //variable for sum of input numbers
            foreach (var number in inputNumbers)
            {
                sum += new Operand(number);
            }

            int c = inputNumbers.Count;
            var N = new Operand((long)c);
            var x = sum / N;

            var Nx2 = N * MathLib.Power(x, new Operand(2)); //N * x^2

            var temp = new Operand(0); //sum(number^2) - N * x^2
            foreach (var number in inputNumbers)
            {
                temp += MathLib.Power(new Operand(number), new Operand(2));
            }

            temp -= Nx2;
            var s = MathLib.Root(temp / (N - new Operand(1)), new Operand(2));
            return s;
        }

        /**
         * @brief Reads one number from STDIN
         *
         * @return Number from STDIN
         */
        private static int ReadNumber()
        {
            string inputBuffer = ""; //buffer for read number
            var inputChar = Console.Read();

            if (inputChar == -1) //EOF
                throw new EndOfStreamException();

            while (Char.IsWhiteSpace(Convert.ToChar(inputChar))) //throwing away white spaces
            {
                inputChar = Console.Read();
                if (inputChar == -1) //EOF
                    throw new EndOfStreamException();
            }

            while (!Char.IsWhiteSpace(Convert.ToChar(inputChar)))
            {
                
                inputBuffer += Convert.ToChar(inputChar);
                inputChar = Console.Read();
                if (inputChar == -1) //EOF
                    return Int32.Parse(inputBuffer);
            }

            return Int32.Parse(inputBuffer);
        }
    }
}
