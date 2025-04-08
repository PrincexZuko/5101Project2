using System;
using System.Collections.Generic;

namespace _5101Project2
{
    class Program{   
        static void Main(string[] args)
        {
            try
            {
                string filePath = @"Data\infix-expressions.json";
                List<InfixExpression> expressions = JsonFile.ParseJson(filePath);

                foreach (var expression in expressions)
                {
                    Console.WriteLine($"Sno: {expression.Sno}, Infix: {expression.Infix}"); //test
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
