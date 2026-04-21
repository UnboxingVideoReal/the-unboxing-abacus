using Accessibility;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public abstract class ConstantTerm : Term
    {
        public override double Coefficient { get; set; }
        public override List<(string, double)> Variables { get; set; } = new List<(string, double)>();
        public ConstantTerm(double var, List<(string, double)> vars)
        {
            this.Coefficient = var;
            this.Variables = vars;
        }

        public override void Eval(List<(string, double)> variables)
        {
            (string, double) variablee = ("", 0);//  (variable, value)
            List<(string, double)> urgrhrguhrgrvariables = variables; // collegeboard wants me to organize my code and have neat names and comments bor im doing that later
            double[] solved = { }; // all the final DOUBLES that we get from constant * x, or just constant alone. ONLY DOUBLES
            int solvediteration = 0; // iterate the array
            foreach ((string, double) v in variables)
            {
                variablee = Variables[List.];
                if (variables.Count >= 1)
                {
                    solved[solvediteration] = Coefficient * v.Item2;
                    urgrhrguhrgrvariables
                }
                else
                {
                    solved[solvediteration] = Coefficient;
                }
                solvediteration += 1;
            }
            double yayaddedocefficient = 0;
            for (int i = 0; i < solved.Length; i++)
            {
                yayaddedocefficient += solved[i];
            }
            this.Coefficient = yayaddedocefficient;


            // todo: add the variable to the global list of variables faxx
            // oh wait i can just
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
