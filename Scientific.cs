using boxMos.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos
{
    public class Scientific
    {
        public static List<Term> Addition(List<Term> terms) // 2 + 2 + x 
        {
            List<(Term, string)> added = new List<(Term, string)>();

            double likeTerm_Constant = 0;
            ConstantTerm likeTerm_Var;
            int son = 0;
            foreach (Term term in terms) 
            {
                if (term.HasVariable)
                {
                    added.Add((term, term.Variables.ToList()[son].Item1)); // (2, ConstantTerm), (2, ConstantTerm), (x, VariableTerm)
                }
                else
                {
                    added.Add((term, "0")); // (2, ConstantTerm), (2, ConstantTerm), (x, VariableTerm)
                }
                son++;
            }
            added = added.OrderBy(t => t.Item2).ToList(); // 2 + 2 + x
            
            for (int i = 0; i < added.Count; i++)
            {
                
            }


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

            return added;
        }
    }
}
