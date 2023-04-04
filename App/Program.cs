using System;

namespace ConsoleApp4
{
    class Program
    {
        static int Main(string[] args)
        {
            string nameOfFile = Console.ReadLine();
            nameOfFile = nameOfFile + ".xml";

            Console.WriteLine(nameOfFile);
            if (ClassLibrary2.Class1.vXML(nameOfFile) == false)
            {
                Console.WriteLine("validation error\n\n");
                return 1;
            }
            else
            {

                Console.WriteLine("validation ok\n\n");
            }
            var k = ClassLibrary2.Class1.Readd(nameOfFile);

            if (k == null)
            {
                Console.WriteLine("readign error");
                return 1;
            }
            foreach(var a in k.events)
            {
                Console.WriteLine(a.name);

                foreach (var aa in a.participant)
                {
                    foreach(var kk in k.people.tortoise)
                    {
                        if(kk.startNumber == aa)
                        {
                            Console.WriteLine(kk.nick);
                        }
                    }
                }
            }
            return 0;
        }
    }
}
