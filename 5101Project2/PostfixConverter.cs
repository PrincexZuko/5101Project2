using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    /*
     * Class Name: PostfixConverter
     * Purpose: Convert infix expressions into postfix notation
     * Methods: ConvertToPostfix(string)
     *          Precedence(char)
     * Coder: KG
     * Date: April 8, 2025
     * Updated By: KL
     * Changes: Updated ConvertToPostfix for performance and clarity 
     *          using StringBuilder and append instead of string concatenation
     */
    public class PostfixConverter
    {
        /*
         * Method name: ConvertToPostfix()
         * Purpose: Convert an infix expression to its equivalent postfix notation.
         * Accepts: string (infix) - The infix expression to be converted.
         * Returns: string[] - The corresponding postfix expression.
         * Coder: KG
         * Date: April 8, 2025
         * Updated By: KL
         * Changes: Return string array instead of a string
         */
        public static string[] ConvertToPostfix(string infix)
        {
            Stack<char> st = new Stack<char>();
            List<string> result = new List<string>();

            foreach (char token in infix)
            {
                if (char.IsLetterOrDigit(token))
                    result.Add(token.ToString());  // Add individual operands (numbers/letters)
                else if (token == '(')
                    st.Push(token);  // Push '(' to the stack
                else if (token == ')')
                {
                    while (st.Count > 0 && st.Peek() != '(')
                        result.Add(st.Pop().ToString());  // Pop operators until '(' is found

                    if (st.Count > 0 && st.Peek() == '(')
                        st.Pop();  // Discard '('
                }
                else // If an operator is scanned
                {
                    while (st.Count > 0 && Precedence(token) <= Precedence(st.Peek()))
                        result.Add(st.Pop().ToString());  // Pop operators of higher or equal precedence

                    st.Push(token);  // Push the current operator onto the stack
                }
            }

            // Pop any remaining operators from the stack
            while (st.Count > 0)
                result.Add(st.Pop().ToString());

            return result.ToArray();  // Return the list of tokens (postfix expression)
        }

        /*
         * Method name: Precedence()
         * Purpose: Determine the precedence of an operator.
         * Accepts: char (op) - The operator to check.
         * Returns: int - The precedence value of the operator.
         * Coder: KG
         * Date: April 8, 2025
         */
        private static int Precedence(char op)
        {
            return op switch
            {
                '^' => 3,
                '*' or '/' => 2,
                '+' or '-' => 1,
                _ => -1, 
            };
        }
    }
}