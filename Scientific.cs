using boxMos.Terms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace boxMos
{
    public class Scientific
    {
        public static List<(Term, string, double)> Addition(List<Term> terms) // 2x + x + 3 + 7
        {
            List<(Term, string, double)> added = new List<(Term, string, double)>();


            int son = 0;
            foreach (Term term in terms)
            {
                Debug.WriteLine(term.ToString_x());
                if (term.HasVariable)
                {
                    
                    added.Add((term, term.Variables.ToList()[son].Item1, term.Variables.ToList()[son].Item2));
                }
                else
                {
                    added.Add((term, "", 1));
                }
                Debug.WriteLine(added[son]);

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
                Debug.WriteLine(listofvars[i]);
            } // "", "x"

            List<(ConstantTerm, string, double)> finalAdded = new List<(ConstantTerm, string, double)>();
            List<(Term, string, double)> actualFinal = new List<(Term, string, double)>();

            foreach (string var in listofvars)
            {
                Debug.WriteLine(var);
                for (int i = added.FindIndex(t => t.Item2 == var); i < added.FindLastIndex(t => t.Item2 == var); i++) // select all the terms that have this variable. if you have 3x + x + 2x + 7, itll eperate into 2 lists, { 3x, x, 2x } and { 7 }
                {
                    finalAdded.Add((added[i].Item1 as ConstantTerm, added[i].Item2, added[i].Item3));
                    Debug.WriteLine(finalAdded[i]);
                }
                for (int tung = 0; tung < finalAdded.Count; tung++) // this is adding them up, probablly gonna erase finalAdded and have a different final variable
                {
                    ConstantTerm sahur = finalAdded[tung].Item1;
                    if (finalAdded[tung].Item2 == "")
                    {
                        if (tung == 0)
                        {
                            sahur = finalAdded[tung].Item1;
                        }
                        else
                        {
                            sahur = new ConstantTerm(finalAdded[tung].Item1.Coefficient + sahur.Coefficient, [("", finalAdded[tung].Item3)]);
                        }
                    }
                    else
                    {
                        if (tung == 0)
                        {
                            sahur = finalAdded[tung].Item1;
                        }
                        else
                        {
                            sahur = new ConstantTerm(finalAdded[tung].Item1.Coefficient + sahur.Coefficient, [(finalAdded[tung].Item2, finalAdded[tung].Item3)]);
                        }

                    }

                    if (tung == finalAdded.Count - 1)
                    {
                        actualFinal.Add((sahur, finalAdded[tung].Item2, finalAdded[tung].Item3));
                    }
                    Debug.WriteLine(actualFinal[tung]);
                }
                finalAdded.Clear();
            }

            Debug.WriteLine(actualFinal);
            return actualFinal;

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
