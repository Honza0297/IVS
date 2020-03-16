/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: Operand.cs
 * Date: 14.3.2020
 * Author: Jan Beran (xberan43@stud.fit.vutbr.cz)
 *
 * Description: Operand class
 *
 *******************************************************************/

using System;

namespace IVSCalc.MathLib
{
    /*
     * @class Operand
     *
     * @brief Purpose of Operand class is to encapsulate the differences between
     * long and double datatypes and provide a simple way to use it in a calculator.
     */
    public class Operand
    {
        private double _doubleOperand;
        public double DoubleOperand
        {
            get => _doubleOperand;
            set
            {
                _doubleOperand = value;
                _longOperand = (long) value;
                Type = TypeOfOperand.Double;
            }
        }

        private long _longOperand;
        public long LongOperand
        {
            get => _longOperand;
            set
            {
                _longOperand = value;
                _doubleOperand = (double) value;
                Type = TypeOfOperand.Long;
            }
        }
        public TypeOfOperand Type { get; private set; }


        /*
         * @brief Constructor for Operand class
         *
         * @param longOperand number to store in Operand class
         */
        public Operand(long longOperand)
        {
            LongOperand = longOperand;
        }

        /*
        * @brief Constructor for Operand class
        *
        * @param doubleOperand number to store in Operand class
        */
        public Operand(double doubleOperand)
        {
            DoubleOperand = doubleOperand;
        }


        /*
         * @brief Override for +
         *
         * @return Result of first + second
         */
        public static Operand operator+(Operand first, Operand second)
        {
            if (first.Type == TypeOfOperand.Double || second.Type == TypeOfOperand.Double)
            {
                double result = first._doubleOperand + second._doubleOperand;
                return new Operand(result);
            }
            else
            {
                long result = first._longOperand + second._longOperand;
                return new Operand(result);
            }
        }

        /*
         * @brief Override for -
         *
         * @return Result of first-second
         */
        public static Operand operator-(Operand first, Operand second)
        {
            if (first.Type == TypeOfOperand.Double || second.Type == TypeOfOperand.Double)
            {
                double result = first._doubleOperand - second._doubleOperand;
                return new Operand(result);
            }
            else
            {
                long result = first._longOperand - second._longOperand;
                return new Operand(result);
            }
        }

        /*
         *
         * @brief Oveeride for *
         *
         * @return result of first*second
         */
        public static Operand operator*(Operand first, Operand second)
        {
            if (first.Type == TypeOfOperand.Double || second.Type == TypeOfOperand.Double)
            {
                double result = first._doubleOperand * second._doubleOperand;
                return new Operand(result);
            }
            else
            {
                long result = first._longOperand * second._longOperand;
                return new Operand(result);
            }
        }

        /*
         * @brief Override for /, handles "zero division" case
         *
         * @return result of first/second
         */
        public static Operand operator/(Operand first, Operand second)
        {
            if(second.LongOperand == 0)
                throw new DivideByZeroException();

            /* When dividing, always use double TODO CHECKME*/
            double result = first._doubleOperand / second._doubleOperand;
            return new Operand(result);
        }

        /*
         * @brief Override for ==, uses Equals(). As Operand is a wrapper for primitive datatypes,
         * the desired behaviour is to Equals() and == be the same. 
         *
         * @return first == second
         */
        public static bool operator== (Operand first, Operand second)
        {
            return first.Equals(second);
        }

        /*
         * @brief Override for !=
         *
         * @return first != second
         */
        public static bool operator!= (Operand first, Operand second)
        {
            return !(first == second);
        }

        /*
         * @brief Checks for equality
         *
         * @return True if objects are equal, False if not
         */
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Operand))
            {
                return false;

            }

            if (Type == TypeOfOperand.Double || ((Operand) obj).Type == TypeOfOperand.Double)
            {
                return this._doubleOperand == ((Operand) obj)._doubleOperand;
            }
            else
            {
                return this._longOperand == ((Operand) obj)._longOperand;
            }
        }

        /*
         * @brief Return HashCode
         *
         * @return HashCode
         */
        public override int GetHashCode()
        {
            return _doubleOperand.GetHashCode() ^ Type.GetHashCode();
        }

        /*
         * @brief Generates string from
         *
         * @return String represenation of Operand.
         */
        public override string ToString()
        {
            if (this.Type == TypeOfOperand.Double)
            {
                return this._doubleOperand.ToString();
            }
            else
            {
                return this._longOperand.ToString();
            }
        }

//TODO operace odmocnina, faktorial
    }
}
