using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxMos.Terms
{
    public abstract class Term
    {
        /// <summary>
        /// calculate as if x was replaced with number
        /// </summary>
        /// <param name="x">number, value of x</param>
        /// <returns></returns>
        public abstract double Eval(string vartodefine, double x);

        /// <summary>
        /// translate to string with x
        /// </summary>
        /// <param name="var">variable, like x</param>
        /// <returns></returns>
        public abstract string ToString_x(string[] vars);
    }
}
