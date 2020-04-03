using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace stddev
{
    public class StandardDeviation
    {
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

        public static Operand CalculateStandardDeviation(IReadOnlyCollection<int> inputNumbers)
        {
            var sum = new Operand(0); //variable for sum of input numbers
            foreach (var number in inputNumbers)
            {
                sum += new Operand(number);
            }

            var N = new Operand(inputNumbers.Count);
            var x = sum / N;

            var Nx2 = N * MathLib.Power(x, new Operand(2)); //N * x^2

            var temp = new Operand(0) - Nx2; //sum(number^2) - N * x^2
            foreach (var number in inputNumbers)
            {
                temp += MathLib.Power(new Operand(number), new Operand(2));
            }

            var s = MathLib.Root(temp / (N - new Operand(1)), new Operand(2));
            return s;
        }

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
                
                inputBuffer += inputChar;
                inputChar = Console.Read();
                if (inputChar == -1) //EOF
                    throw new EndOfStreamException();
            }

            return Int32.Parse(inputBuffer);
        }
    }
}
