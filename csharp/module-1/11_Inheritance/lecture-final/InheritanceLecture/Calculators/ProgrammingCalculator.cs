using System;

namespace InheritanceLecture.Calculators
{
    // A Programming Calculator extends the Calculator class.
    // We say a Programming Calculator "is-a" Calculator.
    public class ProgrammingCalculator : Calculator
    {
        public string ToBinary()
        {
            return Convert.ToString((int)result, 2);
        }
    }
}
