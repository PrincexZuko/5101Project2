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
         * Purpose: Evaluates a prefix expression and returns the result using an expression tree.
         * Accepts: string[] (tokens) - The postfix expression in an array of tokens.
         * Returns: double - The result of the evaluated prefix expression.
         * Coder: KL
         * Date: April 8, 2025
         */
        public static double evaluatePrefix(string[] tokens)
        {
            // Create expression tree from prefix expression
            ExpressionNode root = BuildExpressionTree(tokens, true);

            // Evaluate the expression tree and return the result
            return EvaluateExpressionTree(root);
        }

        /*
         * Method name: evaluatePostfix()
         * Purpose: Evaluates a postfix expression and returns the result using an expression tree.
         * Accepts: string[] (tokens) - The postfix expression in an array of tokens.
         * Returns: double - The result of the evaluated postfix expression.
         * Coder: KL
         * Date: April 8, 2025
         */
        public static double evaluatePostfix(string[] tokens)
        {
            // Create expression tree from postfix expression
            ExpressionNode root = BuildExpressionTree(tokens, false);

            // Evaluate the expression tree and return the result
            return EvaluateExpressionTree(root);
        }

        /*
         * Method name: BuildExpressionTree()
         * Purpose: Constructs an expression tree for either prefix or postfix expressions.
         * Accepts: string[] (tokens) - The expression in array of tokens.
         *          bool isPrefix - Flag to indicate if the expression is in prefix or postfix notation.
         * Returns: ExpressionNode - The root of the constructed expression tree.
         * Coder: KL
         * Date: April 8, 2025
         */
        private static ExpressionNode BuildExpressionTree(string[] tokens, bool isPrefix)
        {
            Stack<ExpressionNode> stack = new Stack<ExpressionNode>();

            if (isPrefix)
            {
                // Iterate over the prefix expression (reversed order)
                for (int i = tokens.Length - 1; i >= 0; i--)
                {
                    string token = tokens[i];
                    if (string.IsNullOrWhiteSpace(token))
                        throw new ArgumentException("Invalid or empty token encountered.");

                    if (char.IsDigit(token[0])) // Operands
                        stack.Push(new ExpressionNode(double.Parse(token)));

                    else if (new[] { "+", "-", "*", "/" }.Contains(token)) // Operators
                    {
                        ExpressionNode node = new ExpressionNode(token);
                        node.Left = stack.Pop();
                        node.Right = stack.Pop();
                        stack.Push(node);
                    }
                    else
                        throw new InvalidOperationException($"Invalid token: {token}");
                }
            }
            else
            {
                // Iterate over the postfix expression
                foreach (string token in tokens)
                {
                    if (string.IsNullOrWhiteSpace(token))
                        throw new ArgumentException("Invalid or empty token encountered.");

                    if (char.IsDigit(token[0])) // Operand
                        stack.Push(new ExpressionNode(double.Parse(token)));

                    else if (new[] { "+", "-", "*", "/" }.Contains(token)) // Operator
                    {
                        ExpressionNode node = new ExpressionNode(token);
                        node.Right = stack.Pop();
                        node.Left = stack.Pop();
                        stack.Push(node);
                    }
                    else
                        throw new InvalidOperationException($"Invalid token: {token}");
                }
            }
            if (stack.Count != 1)
                throw new InvalidOperationException("The expression is invalid.");

            return stack.Pop(); // Return the root of the expression tree
        }

        /*
         * Method name: EvaluateExpressionTree()
         * Purpose: Evaluates the expression tree and returns the result.
         * Accepts: ExpressionNode (root) - The root node of the expression tree.
         * Returns: double - The evaluated result of the expression tree.
         * Coder: KL
         * Date: April 8, 2025
         */
        private static double EvaluateExpressionTree(ExpressionNode node)
        {
            if (node.Left == null && node.Right == null) // If it's a leaf node (operand)
                return node.Value;

            double leftVal = EvaluateExpressionTree(node.Left);  // Evaluate left subtree
            double rightVal = EvaluateExpressionTree(node.Right); // Evaluate right subtree

            // Perform the operation based on the current operator
            switch (node.Operator)
            {
                case "+":
                    return leftVal + rightVal;
                case "-":
                    return leftVal - rightVal;
                case "*":
                    return leftVal * rightVal;
                case "/":
                    if (rightVal == 0)
                        throw new DivideByZeroException("Attempted to divide by zero.");
                    return leftVal / rightVal;
                default:
                    throw new InvalidOperationException($"Invalid operator: {node.Operator}");
            }
        }
    }
}