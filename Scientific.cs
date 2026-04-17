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
            List<Term> added = new List<Term>();

            double likeTerm_Constant = 0;

            for (int i = 0; i < terms.Count; i++)
            {
                added.Add(terms[i]); // (2, ConstantTerm), (2, ConstantTerm), (x, VariableTerm)
            }
            added = added.OrderBy(t => t.GetType().Name).ToList(); // constantterm, 
            for (int i = 0; i < added.Count; i++)
            {
                if (added[i].GetType().Equals(typeof(ConstantTerm)) && added[i + 1].GetType().Equals(typeof(ConstantTerm)) && (added[i] as ConstantTerm).xvar == (added[i + 1] as ConstantTerm).xvar && (added[i] as ConstantTerm).xvar == 1)
                {
                    likeTerm_Constant = (added[i] as ConstantTerm).var + (added[i + 1] as ConstantTerm).var;
                }
                else if (added[i].GetType().Equals(typeof(ConstantTerm)) && added[i + 1].GetType().Equals(typeof(ConstantTerm)) && (added[i] as ConstantTerm).xvar == (added[i + 1] as ConstantTerm).xvar && (added[i] as ConstantTerm).xvar != 1)
                {
                    likeTerm_Constant = (added[i] as ConstantTerm).var + (added[i + 1] as ConstantTerm).var;
                }
            }

            return added;
        }
    }
}
