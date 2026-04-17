using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Deprecated.Terms
{
    public class RationalTerm : Term
    {
        public double numerator { get; }
        public double denominator { get; }
        public RationalTerm(double numerator, double denominator) 
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override double Eval(double x)
        {
            double val = 0;
            val = numerator / (x - denominator);  
            return val;
        }

        public override string ToMath(string var)
        {
            StringBuilder newRational = new StringBuilder();
            if (denominator < 0)
            {
                newRational.Append($"{numerator}/({var}+{-denominator})");
            }
            else
            {
                newRational.Append($"{numerator}/({var}-{denominator})");
            }

            return newRational.ToString();
        }
    }
}
