using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos
{
    internal class Scientific
    {
        public static double Integral(Func<double, double> /* in, out ..?*/ f, double top, double bottom, double dx /* see attached image, split the thing into regions */)
        {
            double sum = 0;
            for (double x = bottom; x < top; x++)
            {
                sum += f(x) * dx; // think of it as width x height, integral is the ok can vsc ai get out its trying to finish my sentence and STOP DOING THAT like it wants me to say "integral is the sum of the areas of rectangles" which is kinda what i wanted to say and its pmoing me off

            }
            return sum;
        }
        public static double Summation(double top, double bottom)
        {
            double sum = 0;
            for (double n = bottom; n <= top; n++)
            {
                sum += n;
            }
            return sum;
        }
        public static List<double> SyntheticDivision(double[] coefficients, double divideby)
        {
            List<double> divided = new List<double>();
            for (int x = 0; x < coefficients.Length; x++)
            {
                if (x == 0)
                {
                    divided.Add(coefficients[x]);
                }
                else
                {
                    divided.Add(divided[x - 1] * divideby + coefficients[x]);
                }
                //Debug.Write(divided[x] + ", ");
            }
            return divided;
        }

        public static string ListToPolynomial(List<double> coefficients, double divideby, string variable)
        {
            StringBuilder newPolynomial = new StringBuilder();
            for (int x = 0; x < coefficients.Count; x++)
            {
                if (x == coefficients.Count - 1)
                {
                    if (coefficients[x] == 0)
                    {
                        newPolynomial.Append(coefficients[x]);
                    }
                    else
                    {
                        newPolynomial.Append(coefficients[x] + $"/{variable}+{-divideby}");
                    }
                }
                else
                {
                    if (x == coefficients.Count - 2)
                    {
                        newPolynomial.Append(coefficients[x] + $"{variable}+");
                    }
                    else
                    {
                        newPolynomial.Append(coefficients[x] + $"{variable}^{coefficients.Count - x - 1}+");
                    }
                }

            }
            return newPolynomial.ToString();
        }

        public static double EvaluatePolynomialFromList(List<double> coefficients, double divideby, double valueOfX)
        {
            List<double> solvedCoefficients = new List<double>();
            double solution = 0;

            // 1,4 - 2 - 1
            // 

            for (int x = 0; x < coefficients.Count; x++)
            {
                if (x == coefficients.Count - 1)
                {
                    if (coefficients[x] == 0)
                    {
                        solvedCoefficients.Add(coefficients[x]);
                    }
                    else
                    {
                        solvedCoefficients.Add(coefficients[x] / (valueOfX+(-divideby)));
                    }
                }
                else
                {
                    if (x == coefficients.Count - 2)
                    {
                        solvedCoefficients.Add(coefficients[x] * valueOfX);
                    }
                    else
                    {
                        solvedCoefficients.Add(coefficients[x] * Math.Pow(valueOfX, coefficients.Count - x));
                    }
                }
                //Debug.Write(solvedCoefficients[x] + ", ");
            }
            solution = solvedCoefficients.Sum();
            return solution;
        }
    }
}
