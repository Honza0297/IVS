using System;

namespace IVSCalc.MathLib
{

    public class MathLibException : Exception
    {
        public MathLibException()
        {
        }

        public MathLibException(string message) : base(message)
        {
            
        }
    }
}