using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using IVSCalc.Entities;

namespace IVSCalc.Models
{
    class CalcModel
    {
        public Operand operandOne { get; set; }
        public Operand operandTwo { get; set; }
        public Operation operation { get; set; }
        public Operand result { get; set; }
    }
}
