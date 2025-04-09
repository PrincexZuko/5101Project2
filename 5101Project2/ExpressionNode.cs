using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    /*
     * Class Name: ExpressionNode
     * Purpose: Represents a node in an expression tree with left and right child nodes and an operator or operand.
     * Coder: KL
     * Date: April 8, 2025
     */
    public class ExpressionNode
    {
        public double Value { get; set; }
        public string Operator { get; set; }
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        // Constructor for a node with a value
        public ExpressionNode(double value)
        {
            Value = value;
            Left = null;
            Right = null;
            Operator = string.Empty; // Not an operator
        }

        // Constructor for a node with an operator
        public ExpressionNode(string operatorSymbol)
        {
            Operator = operatorSymbol;
            Left = null;
            Right = null;
            Value = 0; // No operand value
        }
    }
}
