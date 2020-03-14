using IVSCalc.MathLib;

namespace IVSCalc.Models
{
    class CalcModel
    {
        public Operand OperandOne { get; set; }
        public Operand OperandTwo { get; set; }
        public Operation Operation { get; set; }
        public Operand Result { get; set; }
    }
}
