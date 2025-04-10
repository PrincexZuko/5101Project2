using _5101Project2._5101Project2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

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
 * Coder: KG & KL
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

                    // Combines the postfix tokens into a single string
                    string postfixString = string.Join("", postfixList);
                    // Combines the prefix tokens into a single string
                    string prefixString = string.Join("", prefixList);

                    // Evaluate prefix and postfix expressions
                    double postfixResult = ExpressionEvaluation.evaluatePostfix(postfixList);
                    double prefixResult = ExpressionEvaluation.evaluatePrefix(prefixList);
                    bool match = Math.Round(postfixResult, 2) == Math.Round(prefixResult, 2);

                    // expression's details
                    Console.WriteLine($"\nExpression {expression.Sno}");
                    Console.WriteLine($"Infix   : {infix}");
                    Console.WriteLine($"Postfix : {postfixString}");
                    Console.WriteLine($"Prefix  : {postfixString}");
                    Console.WriteLine($"Postfix Result : {postfixResult}");
                    Console.WriteLine($"Prefix Result  : {prefixResult}");
                    Console.WriteLine($"Match          : {match}");

                    // Add results to the list
                    results.Add(new EvaluationResult
                    {
                        Sno = expression.Sno,
                        InFix = infix,
                        PostFix = postfixString,
                        PreFix = prefixString,
                        PostFixRes = Math.Round(postfixResult, 2),
                        PreFixRes = Math.Round(prefixResult, 2),
                        Match = match
                    });
                }

                // Print summary report
                PrintSummaryReport(results);

                // After processing all expressions and collecting the results, generate the XML
                GenerateXMLFile(results);

                //Prompt to upload and view XML in browser
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

            // Separator length updated for tighter alignment with headers and rows
            string separator = new string('=', 120);
            string header = $"|{"Sno",-5}|{"InFix",-25}|{"PostFix",-25}|{"PreFix",-25}|{"Prefix Res",-12}|{"PostFix Res",-12}|{"Match",-8}|";

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            foreach (var res in results)
            {
                Console.WriteLine(
                    $"|{res.Sno,-5}|{res.InFix,-25}|{res.PostFix,-25}|{res.PreFix,-25}|{res.PreFixRes,-12}|{res.PostFixRes,-12}|{(res.Match ? "True" : "False"),-8}|"
                );
            }

            Console.WriteLine(separator);
        }




        static void GenerateXMLFile(List<EvaluationResult> results)
        {
            try
            {
                // Get the project directory
                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                // Construct the full path for the Data folder and the XML file
                string dataFolderPath = Path.Combine(projectDirectory, "Data");
                string xmlFilePath = Path.Combine(dataFolderPath, "summary.xml");

                // Create the XML file using the constructed path
                using (XmlWriter writer = XmlWriter.Create(xmlFilePath, new XmlWriterSettings
                {
                    Indent = true,             // Enable indentation
                    IndentChars = "  ",        // Use two spaces per indentation level
                    NewLineChars = "\n",       // Newline for each element
                    NewLineHandling = NewLineHandling.Replace
                }))
                {
                    // Start the XML document
                    writer.WriteStartDocument();

                    // Start the root element
                    writer.WriteStartElement("root");

                    // Loop through each result and create corresponding XML elements
                    foreach (var res in results)
                    {
                        // Start the 'expression' element
                        writer.WriteStartElement("expression");

                        // Write individual elements for each part of the result
                        writer.WriteElementString("sno", res.Sno.ToString());
                        writer.WriteElementString("infix", res.InFix);
                        writer.WriteElementString("prefix", res.PreFix);
                        writer.WriteElementString("postfix", res.PostFix);
                        writer.WriteElementString("prefix_eval", res.PreFixRes.ToString());
                        writer.WriteElementString("postfix_eval", res.PostFixRes.ToString());
                        writer.WriteElementString("comparison", res.Match.ToString().ToLower());

                        // End the 'expression' element
                        writer.WriteEndElement();
                    }

                    // End the root element
                    writer.WriteEndElement();

                    // End the XML document
                    writer.WriteEndDocument();

                    Console.WriteLine($"XML file generated successfully at: {xmlFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while generating XML file: {ex.Message}");
            }
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
