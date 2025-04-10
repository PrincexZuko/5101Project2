﻿using _5101Project2._5101Project2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _5101Project2
{

    /*
 * Class Name: Program
 * Purpose: Entry point for the application to evaluate a set of infix arithmetic expressions 
 *          by converting them into postfix and prefix notation and performing evaluations.
 * Methods:
 *      Main: Reads input, converts expressions, evaluates them, and displays results.
 *      PrintSummaryReport: Neatly displays the summary report of all evaluated expressions.
 *      PromptAndOpenXml: Prompts the user for an XML file path and opens it in the web browser.
 * Accepts: Input JSON file path containing infix expressions.
 * Returns: Console output displaying conversion results and evaluation, generates an XML file.
 * Coder: KG
 * Date: April 8, 2025
 */

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = @"Data\infix-expressions.json";
                List<InfixExpression> expressions = JsonFile.ParseJson(filePath);
                List<EvaluationResult> results = new List<EvaluationResult>();

                foreach (var expression in expressions)
                {
                    // retrieve the infix expression
                    string infix = expression.Infix;

                    // Convert infix to postfix and prefix
                    string[] postfixList = PostfixConverter.ConvertToPostfix(infix);
                    string[] prefixList = PrefixConverter.ConvertToPrefix(infix);

                    // Evaluate prefix and postfix expressions
                    double postfixResult = ExpressionEvaluation.evaluatePostfix(postfixList);
                    double prefixResult = ExpressionEvaluation.evaluatePrefix(prefixList);
                    bool match = Math.Round(postfixResult, 2) == Math.Round(prefixResult, 2);

                    // expression's details
                    Console.WriteLine($"\nExpression {expression.Sno}");
                    Console.WriteLine($"Infix   : {infix}");
                    Console.WriteLine($"Postfix : {postfix}");
                    Console.WriteLine($"Prefix  : {prefix}");
                    Console.WriteLine($"Postfix Result : {postfixResult}");
                    Console.WriteLine($"Prefix Result  : {prefixResult}");
                    Console.WriteLine($"Match          : {match}");

                    // Add results to the list
                    results.Add(new EvaluationResult
                    {
                        Sno = expression.Sno,
                        InFix = infix,
                       // PostFix = postfix,
                       // PreFix = prefix,
                        PostFixRes = Math.Round(postfixResult, 2),
                        PreFixRes = Math.Round(prefixResult, 2),
                        Match = match
                    });
                }

                // Print summary report
                PrintSummaryReport(results);
                PromptAndOpenXml();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void PrintSummaryReport(List<EvaluationResult> results)
        {
            Console.WriteLine("\nThe Sample Output");
            Console.WriteLine("The Summary Report\n");

            string separator = new string('=', 110);
            string header = $"|{"Sno",-4}|{"InFix",-15}|{"PostFix",-15}|{"PreFix",-15}|{"Prefix Res",-10}|{"PostFix Res",-12}|{"Match",-6}|";

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            foreach (var res in results)
            {
                Console.WriteLine(
                    $"|{res.Sno,-4}|{res.InFix,-15}|{res.PostFix,-15}|{res.PreFix,-15}|{res.PreFixRes,-10}|{res.PostFixRes,-12}|{(res.Match ? "True" : "False"),-6}|"
                );
            }

            Console.WriteLine(separator);
        }

        static void PromptAndOpenXml()
        {
            Console.Write("\nPlease enter the full path to the XML file you want to view in your browser: ");
            string xmlPath = Console.ReadLine();

            if (File.Exists(xmlPath))
            {
                Console.WriteLine("Opening the XML file in your default web browser...");
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = xmlPath,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            else
            {
                Console.WriteLine("File not found. Please double-check the path.");
            }
        }
    }
}
