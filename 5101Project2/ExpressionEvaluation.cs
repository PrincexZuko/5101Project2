using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    public class ExpressionEvaluation
    {
        /*
         * Method name: evaluatePrefix()
         * Purpose: Evaluates a prefix mathematical expression and returns the result.
         * Accepts: string (exprsn) - The prefix expression to evaluate.
         * Returns: double - The result of the evaluated prefix expression.
         * Coder: KL
         * Date: April 8, 2025
         */
        public static double evaluatePrefix(String exprsn)
        {
            Stack<Double> stack = new Stack<Double>();

            for (int j = exprsn.Length - 1; j >= 0; j--)
            {
                char token = exprsn[j];

                // If the token is a number, push it onto the stack
                if (char.IsDigit(token))
                    stack.Push(char.GetNumericValue(token));
                else
                {
                    // Operator encountered, Pop two elements from Stack
                    double operand1 = stack.Pop(); // Pop the first operand
                    double operand2 = stack.Pop(); // Pop the second operand

                    // Use switch case to operate on operand1 or operand2
                    switch (token)
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }
            return stack.Pop(); // Return the result and clear the stack
        }

        /*
         * Method name: evaluatePostfix()
         * Purpose: Evaluates a postfix mathematical expression and returns the result.
         * Accepts: string[] (arr) - The postfix expression in an array of tokens.
         * Returns: double - The result of the evaluated postfix expression.
         * Coder: KL
         * Date: April 8, 2025
         */
        public static double evaluatePostfix(string[] arr)
        {
            Stack<double> stack = new Stack<double>();

            foreach (string token in arr)
            {
                // If the token is a number, push it onto the stack
                if (char.IsDigit(token[0]))
                    stack.Push(char.GetNumericValue(token[0]));
                else
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }
            return stack.Pop(); // Return the result and clear the stack
        }
    }
}