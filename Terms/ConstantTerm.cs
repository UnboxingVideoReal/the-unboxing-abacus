using Accessibility;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public class ConstantTerm : Term
    {
        public override double Coefficient { get; set; }
        // variables their name and their valuie if they have one
        public override List<(string, double)> Variables { get; set; } = new List<(string, double)>();

        public override bool HasVariable { get; set; }
        public ConstantTerm(double var, List<(string, double)> vars)
        {
            this.Coefficient = var;
            this.Variables = vars;
            this.HasVariable = vars.Any();
        }

        public override void Eval(List<(string, double)> variables)
        {
            (string, double) variablee = ("", 0);
            List<(string, double)> urgrhrguhrgrvariables = variables; 
            // all defined doubles
            double[] solved = { };
            int solvediteration = 0; // iterate the array
            foreach ((string, double) v in variables)
            {
                variablee = Variables[variables.IndexOf(v)];
                if (variables.Count >= 1)
                {
                    solved[solvediteration] = Coefficient * v.Item2;
                    urgrhrguhrgrvariables.Remove(v);
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
        }

        public override string ToString_x()
        {
            string combinedexpression = "";
            if (Variables.Count >= 1)
            {
                foreach ((string, double) var in Variables)
                {
                    combinedexpression += var.Item1.ToString() + " + ";
                }
                return combinedexpression + Coefficient.ToString();
            }
            else
            {
                return Coefficient.ToString();
            }
        }
    }
}
