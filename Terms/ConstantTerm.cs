using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public abstract class ConstantTerm : Term
    {
        public override double Coefficient { get; }
        public override Tuple<string, double>[] Variables { get; } = Array.Empty<Tuple<string, double>>();
        public ConstantTerm(double var, Tuple<string, double>[] vars)
        {
            this.Coefficient = var;
            this.Variables = vars;
        }

        public override double Eval(Tuple<string, double>[] variables)
        {
            Tuple<string, double> variablee = new Tuple<string, double>("", 0);
            foreach (Tuple<string, double> v in variables)
            {
                variablee = Variables[Array.IndexOf(variables, v.Item2)];
            }
            // todo: add the variable to the global list of variables faxx
            if (variables.Length >= 1)
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
