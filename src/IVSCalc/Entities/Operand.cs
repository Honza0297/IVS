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

namespace IVSCalc.Entities
{
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



        public Operand(long longOperand)
        {
            LongOperand = longOperand;
        }

        public Operand(double doubleOperand)
        {
            DoubleOperand = doubleOperand;
        }

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

        public static Operand operator/(Operand first, Operand second)
        {
            if(second.LongOperand == 0)
                throw new DivideByZeroException();

            /* When dividing, always use double TODO CHECKME*/
            double result = first._doubleOperand / second._doubleOperand;
            return new Operand(result);
        }

        public static bool operator== (Operand first, Operand second)
        {
            if (first.Type == TypeOfOperand.Double || second.Type == TypeOfOperand.Double)
            {
                return first.DoubleOperand == second.DoubleOperand;
            }
            else
            {
                return first.LongOperand == second.LongOperand;
            }
        }

        public static bool operator!= (Operand first, Operand second)
        {
            return !(first == second);
        }

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
                return this.DoubleOperand == ((Operand) obj).DoubleOperand;
            }
            else
            {
                return this.LongOperand == ((Operand) obj).LongOperand;
            }
        }

        public override int GetHashCode()
        {
            return DoubleOperand.GetHashCode() ^ Type.GetHashCode();
        }


//TODO operace odmocnina, faktorial
    }
}