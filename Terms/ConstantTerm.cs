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

        public override Term[] Eval(Tuple<string, double>[] variables)
        {
            Tuple<string, double> variablee = new Tuple<string, double>("", 0);//  (variable, value)
            double[] solved = { }; // all the final DOUBLES that we get from constant * x, or just constant alone. ONLY DOUBLES
            int solvediteration = 0; // iterate the array
            foreach (Tuple<string, double> v in variables)
            {
                variablee = Variables[Array.IndexOf(variables, v.Item2)];
                if (variables.Length >= 1)
                {
                    solved[solvediteration] = Coefficient * v.Item2;
                }
                else
                {
                    return var;
                }
                solvediteration += 1;
            }
            // todo: add the variable to the global list of variables faxx
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
