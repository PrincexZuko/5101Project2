using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _5101Project2
 {
    /**
     * Class Name: PrefixConverter
     * Purpose: Convert infix expressions into prefix notation
     * Methods: ConvertToPrefix()
     * Coder: KG
     * Date: April 8, 2025
     */
    public class PrefixConverter
        {
            public static string ConvertToPrefix(string infix)
            {
                char[] arr = infix.ToCharArray();
                Array.Reverse(arr);
                infix = new string(arr);

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == '(')
                    {
                        arr[i] = ')';
                    }
                    else if (arr[i] == ')')
                    {
                        arr[i] = '(';
                    }
                }
                // Convert reversed infix to postfix
                string postfix = ConvertToPostfix(new string(arr));

                // Reverse the postfix expression to get prefix
                char[] postArr = postfix.ToCharArray();
                Array.Reverse(postArr);
                return new string(postArr);
            }
        
        // Convert infix expression to postfix notation
        private static string ConvertToPostfix(string infix)
            {
                Stack<char> st = new Stack<char>();
                string res = "";
                int sz = infix.Length;

                for (int i = 0; i < sz; i++)
                {
                    char ch = infix[i];

                    if (char.IsLetterOrDigit(ch))
                    { res += ch;
                    } else if (ch == '('){
                        st.Push(ch);
                    } else if (ch == ')')
                    {
                       while (st.Count > 0 && st.Peek() != '('){
                            res += st.Pop();
                        }
                        st.Pop();
                    } else
                    {
                        while (st.Count > 0 && OperatorPrecedence(ch) <= OperatorPrecedence(st.Peek()))
                        {
                            res += st.Pop();
                        }
                        st.Push(ch);
                    }
                }

                while (st.Count > 0){
                    res += st.Pop();
                }

                return res;
            }

        // Get precedence of operators
        private static int OperatorPrecedence(char op)
            {
                return op switch
                {
                    '^' => 3,
                    '*' or '/' => 2,
                    '+' or '-' => 1,
                    _ => -1,
                };
            }

            private static bool IsOperator(char ch) => "+-*/^".Contains(ch);
        }
    }

