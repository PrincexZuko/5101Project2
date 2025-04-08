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
        public static List<InfixExpression> ParseJson(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
            // Read all text from the file
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
