using _5101Project2._5101Project2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    /*
     * Class Name: CompareExpressions
     * Purpose: Compare prefix and postfix evaluation results.
     * Methods: Compare()
     * Coder: KG
     * Date: April 8, 2025
     */
    public class CompareExpressions : IComparer<EvaluationResult>
    {
        /*
         * Method name: Compare()
         * Purpose: Compare prefix and postfix evaluation results for a given expression.
         * Accepts: EvaluationResult (x, y)
         * Returns: int
         * Coder: KG
         * Date: April 9, 2025
         */
        public int Compare(EvaluationResult x, EvaluationResult y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("One or both objects to compare are null.");

            if (Math.Abs(x.PreFixRes - x.PostFixRes) < 0.0001)
            {
                return 0;             
            }
            return x.PreFixRes > x.PostFixRes ? 1 : -1;
        }
    }
}
