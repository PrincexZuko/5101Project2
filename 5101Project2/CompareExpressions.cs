using _5101Project2._5101Project2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    public class CompareExpressions : IComparer<string[]>
    {
        /*
         * Method name: Compare
         * Purpose: Compares the results of evaluating two expressions (prefix and postfix).
         * Accepts: Two string arrays representing the tokens of prefix and postfix expressions.
         * Returns: int - Comparison result (-1 if prefixResult is smaller, 1 if prefixResult is greater, 0 if equal).
         * Coder: KL
         * Date: April 8, 2025
         */
        public int Compare(string[] prefixExpression, string[] postfixExpression)
        {
            // Ensure that both inputs are valid, or handle them if they're not.
            if (prefixExpression == null || postfixExpression == null)
                throw new ArgumentException("Expressions cannot be null.");

            // Evaluate both the expressions (prefix and postfix)
            double prefixResult = ExpressionEvaluation.evaluatePrefix(prefixExpression);
            double postfixResult = ExpressionEvaluation.evaluatePostfix(postfixExpression);

            // Compare the results
            if (prefixResult == postfixResult)
                return 0;  // They match
            else
                return prefixResult < postfixResult ? -1 : 1;  // Return -1 if prefixResult is smaller, 1 if prefixResult is greater
        }
    }
}