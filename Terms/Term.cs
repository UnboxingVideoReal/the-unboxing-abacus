using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public abstract class Term
    {
        public abstract double Eval(double x);

        public abstract string ToMath(string var);
    }
}
