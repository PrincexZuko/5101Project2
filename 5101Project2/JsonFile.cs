using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace _5101Project2
{
    public class JsonFile
    {
    /*
     * Method name: ParseJson()
     * Purpose: Read and deserialize the JSON file into a generic list of InfixExpression objects.
     * Accepts: string (filePath)
     * Returns: List<InfixExpression>
     * Coder: KG
     * Date: April 8, 2025
     * Updated By: KL
     * Changes: added aditional error checking and refined variables for clarity
     */
        public static List<InfixExpression> ParseJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
            // Read the file and deserialize it into a List of InfixExpression objects
            string jsonContent = File.ReadAllText(filePath);
            var expressions = JsonConvert.DeserializeObject<List<InfixExpression>>(jsonContent);

            // Error Checking
            if (expressions == null)
            {
                throw new InvalidDataException("Failed to deserialize JSON content.");
            }

            return expressions;
        }
    }
}