﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calc
{
    public class Divider : ICalc
    {
        public double DoMath(double a, double b)
        {
            if (a == 0 || b == 0)
                return 0;

            return a / b;
        }
    }
}
