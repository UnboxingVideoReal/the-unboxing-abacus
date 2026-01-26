using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public class ConstantTerm : Term
    {
        public string var = "";
        public ConstantTerm(string var) 
        {
            this.var = var;
        }

        public override double Eval(double x)
        {
            double val = 0;
            return val;
        }

        public override string ToMath(string var)
        {
            return var;
        }
    }
}
