using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Deprecated.Terms
{
    public class LogarithmTerm : Term
    {
        public List<double> coefficients = new List<double>();
        public Term parameter;
        public LogarithmTerm(List<double> coefficient, Term parameter) 
        {
            this.coefficients = coefficient;
            this.parameter = parameter;
        }

        public override double Eval(double x)
        {
            double val = 0;
            foreach (var c in coefficients)
            {
                val = val * (x * Math.Log(Math.Abs(c)));
            }    
            return val;
        }

        public override string ToMath(string var)
        {
            StringBuilder newPolynomial = new StringBuilder();
            int i = 0;
            foreach (var c in coefficients)
            {
                double power = coefficients.Count - i - 1;

                char sign;
                if (c < 0)
                {
                    sign = '-';
                }
                else
                {
                    sign = '+';
                }
                double absoluteConstant = Math.Abs(c);
                if (i == 0)
                {
                    if (c == 1 || c == -1)
                    {
                        if (c < 0)
                        {
                            if (power == 1)
                            {
                                newPolynomial.Append("-" + var);
                            }
                            else if (power == 0)
                            {
                                //newPolynomial.Append("-" + c);
                            }
                            else
                            {
                                newPolynomial.Append("-" + var + "^" + power);
                            }
                        }
                        else
                        {
                            if (power == 1)
                            {
                                newPolynomial.Append(var);
                            }
                            else if (power == 0)
                            {
                                //newPolynomial.Append(c);
                            }
                            else
                            {
                                newPolynomial.Append(var + "^" + power);
                            }
                        }
                    }
                    else
                    {
                        if (c < 0)
                        {
                            if (power == 1)
                            {
                                newPolynomial.Append("-" + c + var);
                            }
                            else if (power == 0)
                            {
                                //newPolynomial.Append("-" + c);
                            }
                            else
                            {
                                newPolynomial.Append("-" + c + var + "^" + power);
                            }
                        }
                        else
                        {
                            if (power == 1)
                            {
                                newPolynomial.Append(c + var);
                            }
                            else if (power == 0)
                            {
                                //newPolynomial.Append(c);
                            }
                            else
                            {
                                newPolynomial.Append(c + var + "^" + power);
                            }
                        }
                    }
                }
                else
                {
                    if (c == 1 || c == -1)
                    {

                        if (power == 1)
                        {
                            newPolynomial.Append(" " + sign + " " + var);
                        }
                        else if (power == 0)
                        {
                            newPolynomial.Append(" " + sign + " " + absoluteConstant);
                        }
                        else
                        {
                            newPolynomial.Append(" " + sign + " " + var + "^" + power);
                        }
                    }
                    else
                    {
                        if (power == 1)
                        {
                            newPolynomial.Append(" " + sign + " " + absoluteConstant + var);
                        }
                        else if (power == 0)
                        {
                            newPolynomial.Append(" " + sign + " " + absoluteConstant);
                        }
                        else
                        {
                            newPolynomial.Append(" " + sign + " " + absoluteConstant + var + "^" + power);
                        }

                    }
                }
                i++;
            }
            return newPolynomial.ToString() + " + C";
        }
    }
}
