using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calc
{
    public class Substractor : ICalc
    {
        public double DoMath(double a, double b)
        {
            return a - b;
        }
    }
}
