using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5101Project2
{
    /*
     * Class Name: XMLExtension
     * Purpose: Provides extension methods for the StreamWriter class to help with XML writing.
     * Methods: 
     *      WriteStartDocument(): Writes the XML declaration with version and encoding.
     *      WriteStartElement(string): Writes the opening tag for an XML element.
     *      WriteEndElement(string): Writes the closing tag for an XML element.
     *      WriteSimpleElement(string, string): Writes a full XML element with name and value.
     * Coder: KL
     * Date: April 8, 2025
     */
    public static class XMLExtension
    {
        /*
         * Method name: WriteStartDocument()
         * Purpose: Write the XML declaration to the file with version and encoding.
         * Accepts: StreamWriter (writer)
         * Returns: void
         * Coder: KL
         * Date: April 8, 2025
         */
        public static void WriteStartDocument(this StreamWriter writer)
        {
            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        }

        /*
         * Method name: WriteStartElement()
         * Purpose: Write the opening tag for an XML element.
         * Accepts: StreamWriter (writer), string (element name)
         * Returns: void
         * Coder: KL
         * Date: April 8, 2025
         */
        public static void WriteStartElement(this StreamWriter writer, string elementName)
        {
            writer.WriteLine($"<{elementName}>");
        }

        /*
         * Method name: WriteEndElement()
         * Purpose: Write the closing tag for an XML element.
         * Accepts: StreamWriter (writer), string (element name)
         * Returns: void
         * Coder: KL
         * Date: April 8, 2025
         */
        public static void WriteEndElement(this StreamWriter writer, string elementName)
        {
            writer.WriteLine($"</{elementName}>");
        }

        /*
         * Method name: WriteSimpleElement()
         * Purpose: Write an XML element with simple content (value).
         * Accepts: StreamWriter (writer), string (element name), string (element value)
         * Returns: void
         * Coder: KL
         * Date: April 8, 2025
         */
        public static void WriteSimpleElement(this StreamWriter writer, string elementName, string value)
        {
            writer.WriteLine($"<{elementName}>{value}</{elementName}>");
        }
    }
}