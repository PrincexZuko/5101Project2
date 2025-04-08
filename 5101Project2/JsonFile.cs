using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
     */
        public static List<InfixExpression> ParseJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<InfixExpression>>(jsonContent);
        }
    }

    // class structure for JSON data
    public class InfixExpression
    {
        public int Sno { get; set; } 
        public string Infix { get; set; } 
    }
}
