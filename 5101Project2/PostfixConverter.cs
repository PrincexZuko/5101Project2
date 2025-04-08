using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    namespace _5101Project2
    {
        /**
         * Class Name: PostfixConverter
         * Purpose: Convert infix expressions into postfix notation
         * Methods: ConvertToPostfix()
         * Coder: KG
         * Date: April 8, 2025
         */
        public class PostfixConverter
        {
            public static string ConvertToPostfix(string infix)
            {
                Stack<char> st = new Stack<char>();
                string result = ""; 

                foreach (char c in infix)
                {
                    if (char.IsLetterOrDigit(c))
                    { result += c;
                    } else if (c == '(')
                    { st.Push(c);
                    } else if (c == ')')
                    {
                        while (st.Count > 0 && st.Peek() != '(')
                        {
                            result += st.Pop();
                        }
                        st.Pop();
                        
                    // If an operator is scanned
                    } else
                    {
                        while (st.Count > 0 && Precedence(c) <= Precedence(st.Peek()))
                        {
                            result += st.Pop();
                        }
                        st.Push(c); 
                    }
                }

                while (st.Count > 0)
                {
                    result += st.Pop();
                }

                return result;
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
}
