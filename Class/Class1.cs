using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ClassLibrary2
{
    public class Class1
    {
        public static bool vXML(string path)
        {
            path = @"C:\Users\majb\source\repos\ClassLibrary2" + "\\" + path;
            bool flag = true;
            void ValidationHandler(Object sender, ValidationEventArgs args)
            {
                if (args.Severity == XmlSeverityType.Warning)
                    Console.WriteLine("Warning: {0}", args.Message);
                else
                {
                    flag = false;
                    Console.WriteLine("Error: {0}", args.Message);
                }
            }
            XmlReaderSettings settings = new XmlReaderSettings();
            // Ustawienia walidacji
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

            // Dodanie pliku xsd dla danej przestrzeni nazw
            // Chcemy dodać zdefiniowaną w zadaniu przestrzeń. 
            // (Tak jak w ustawieniach XML -> Schemas w VS
            settings.Schemas.Add("my.for", @"C:\Users\majb\source\repos\ClassLibrary2\ex.xsd");

            // Przetwarzanie schemaLocation z XSI
            // Domyślnie wyłączone ze względów bezpieczeństwa
            // (można zmusić program do przeczytania dowolnego pliku). 
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;

            // Funkcja, która będzie obsługiwać pojawiające się błędy walidacji
            // Może zostać wywołana wielokrotnie dla jednego dokumentu
            settings.ValidationEventHandler += ValidationHandler;

            XmlReader reader = XmlReader.Create(path, settings);

            // Read odczytuje kolejny element/atrybut z dokumentu. 
            // Moze spowodować wywołanie delegacji przypiętej do ValidationEventHandler. 
            while (reader.Read())
            {
            }
            return flag;
        }

        public static formulaT Readd(string path)
        {
            path = @"C:\Users\majb\source\repos\ClassLibrary2" + "\\" + path;
            XmlSerializer serializer = new XmlSerializer(typeof(formulaT));

            // Declare an object variable of the type to be deserialized.
            formulaT i;

            Stream r = File.OpenRead(path);
            i = (formulaT)serializer.Deserialize(r);

            return i;
        }
    }
}
