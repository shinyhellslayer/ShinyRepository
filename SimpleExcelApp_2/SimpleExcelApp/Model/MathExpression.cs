using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExcelApp.Model
{
    public class MathExpression
    {
        public string[] mathPlusSymbol { get; set; }
        public int[] mathMinusSymbol { get; set; }
        public int[] mathDevideSymbol { get; set; }
        public int[] mathMultiplySymbol { get; set; }
        public int[] mathSymbol { get; set; }
        public int mathExpressionSymbol { get; set; }
        public string mathCalculationSymbol { get; set; }
    }
}
