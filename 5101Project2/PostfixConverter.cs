using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    /**
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
        public static string ConvertToPostfix(string infix)
        {
            Stack<char> st = new Stack<char>();
            StringBuilder result = new StringBuilder(); 

            foreach (char token in infix)
            {
                if (char.IsLetterOrDigit(token))
                    result.Append(token);
                else if (token == '(')
                    st.Push(token);
                else if (token == ')')
                {
                    while (st.Count > 0 && st.Peek() != '(')
                        result.Append(st.Pop());

                    if(st.Count > 0)
                        st.Pop(); // Remove '('
                }
                else // If an operator is scanned
                {
                    while (st.Count > 0 && Precedence(token) <= Precedence(st.Peek()))
                        result.Append(st.Pop());

                    st.Push(token); 
                }
            }

            while (st.Count > 0)
                result.Append(st.Pop());

            //convert StringBuilder object to string and return
            return result.ToString();
        }

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