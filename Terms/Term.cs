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
        /// the number infront of a variable, or in itself, a constant integer/decimal whatever
        /// </summary>
        /// <returns>double</returns>
        
        public abstract double Coefficient { get; set;  } 

        /// <summary>
        /// an array of tuples of mathematical variable names and inputs
        /// </summary>
        /// <returns>an array of strings and doubles</returns>

        public abstract List<(string, double)> Variables { get; set; }

        /// <summary>
        /// boolean to check if the term has any variable at all
        /// </summary>
        /// <returns>true if 1 or more variable, false if not</returns>
        
        public abstract bool HasVariable { get; }

        /// <summary>
        /// calculate as if x was replaced with number
        /// </summary>
        /// <param name="x">number, value of x</param>
        /// <returns>an expression, or a number</returns>
        
        public abstract void Eval(List<(string, double)> variables);

        /// <summary>
        /// translate to string with x
        /// </summary>
        /// <param name="var">variable, like x</param>
        /// <returns></returns>
        
        public abstract string ToString_x(string[] vars);
    }
}
