namespace _5101Project2
{
    /*
     * Class Name: PrefixConverter
     * Purpose: Convert infix expressions into prefix notation
     * Methods: ConvertToPrefix()
     * Coder: KG
     * Date: April 8, 2025
     * Updated By: KL
     * Changes: Removed redundant methods
     */
    public class PrefixConverter
    {
        /*
         * Method name: ConvertToPrefix()
         * Purpose: Convert a given infix expression into prefix notation.
         * Accepts: string (infix) - The infix expression to be converted.
         * Returns: string[] - The converted prefix expression.
         * Coder: KG
         * Date: April 8, 2025
         * Updated By: KL
         * Changes: Return string array instead of a string
         */
        public static string[] ConvertToPrefix(string infix)
        {
            char[] arr = infix.ToCharArray();
            Array.Reverse(arr);
            infix = new string(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '(')
                    arr[i] = ')';
                else if (arr[i] == ')')
                    arr[i] = '(';
            }
            // Convert reversed infix to postfix
            string[] postfixArray = PostfixConverter.ConvertToPostfix(new string(arr));

            // Reverse the postfix expression to get prefix
            Array.Reverse(postfixArray);

            return postfixArray;
        }
    }
}