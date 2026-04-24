using boxMos.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace boxMos
{
    public class Scientific
    {
        public static List<(Term, string)> Addition(List<Term> terms) // 2x + x + 3 + 7
        {
            List<(Term, string)> added = new List<(Term, string)>();
            List<double> definedvar = new List<double>(); 


            int son = 0;
            foreach (Term term in terms)
            {
                if (term.HasVariable)
                {
                    added.Add((term, term.Variables.ToList()[son].Item1));
                    definedvar.Add(term.Variables.ToList()[son].Item2);
                }
                else
                {
                    added.Add((term, ""));
                    definedvar.Add(1);
                }
                son++;
            } // 2x, x, 3, 7 -> (2x, "x"), (x, "x"), (3, ""), (7, "")
            added = added.OrderBy(t => t.Item2).ToList(); // 2x + x + 3 + 7 / 3 + 7 + 2x + x

            List<string> listofvars = new List<string>();
            for (int i = 0; i < added.Count; i++)
            {
                if (listofvars.Contains(added[i].Item2))
                {

                }
                else
                {
                    listofvars.Add(added[i].Item2);
                }
            }

            List<(ConstantTerm, string)> finalAdded = new List<(ConstantTerm, string)>();
            foreach (string var in listofvars)
            {
                for (int i = added.FindIndex(t => t.Item2 == var); i < added.FindLastIndex(t => t.Item2 == var); i++) // now that we have the list of terms ordered by variable, we now split that list into chunks of varibales. eg: line 30 becomes { 2x, x } and { 3, 7 }.
                {
                    finalAdded.Add((added[i].Item1 as ConstantTerm, added[i].Item2));
                }
                for (int tung = 0; tung < finalAdded.Count; tung++)
                {
                    ConstantTerm sahur;
                    if (finalAdded[tung].Item2 == "")
                    {
                        if (tung == 0)
                        {
                            sahur = finalAdded[tung].Item1;
                        }
                        else
                        {
                            sahur = new ConstantTerm(finalAdded[tung].Item1.Coefficient + sahur.Coefficient, [("", definedvar[tung])]);
                        }
                    }
                }
            }


            return added;

            //for (int i = 0; i < terms.Count; i++)
            //{
            //    if (added[i].Item1.HasVariable && added[i + 1].Item1.HasVariable)
            //    {
            //        likeTerm_Var = 
            //    }
            //}
                                                          //for (int i = 0; i < added.Count; i++)
            //{

            //    //if (added[i].GetType().Equals(typeof(ConstantTerm)) && added[i + 1].GetType().Equals(typeof(ConstantTerm)) && (added[i] as ConstantTerm).xvar == (added[i + 1] as ConstantTerm).xvar && (added[i] as ConstantTerm).xvar == 1)
            //    //{
            //    //    likeTerm_Constant = (added[i] as ConstantTerm).var + (added[i + 1] as ConstantTerm).var;
            //    //}
            //    //else if (added[i].GetType().Equals(typeof(ConstantTerm)) && added[i + 1].GetType().Equals(typeof(ConstantTerm)) && (added[i] as ConstantTerm).xvar == (added[i + 1] as ConstantTerm).xvar && (added[i] as ConstantTerm).xvar != 1)
            //    //{
            //    //    likeTerm_Constant = (added[i] as ConstantTerm).var + (added[i + 1] as ConstantTerm).var;
            //    //}
            //}
        }
    }
}
