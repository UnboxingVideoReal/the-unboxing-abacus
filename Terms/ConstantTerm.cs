using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public abstract class ConstantTerm : Term
    {
        public double var { get; set; }
        public string[] vars { get; set; } = { };
        public ConstantTerm(double var, string[] vars)
        {
            this.var = var;
            this.vars = vars;
        }

        public override double Eval(string vartodefine, double x)
        {
            string variablee = vars[Array.IndexOf(vars, vartodefine)];
            // todo: add the variable to the global list of variables faxx
            if (vars.Length >= 1)
            {
                return var * x;
            }
            else
            {
                return var;
            }
        }

        public override string ToString_x(string[] vars)
        {
            if (vars.Length >= 1)
            {
                return vars[0] + var.ToString();
            }
            else
            {
                return var.ToString();
            }
        }
    }
}
