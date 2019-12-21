using System;
using System.IO;

namespace ProgramSklep
{
    class Program
    {
        static void Main(string[] args)
        {
        

            int UserInput=0;
            
            //menu
            int x=0;
            while (x<1)
            {
                System.Console.WriteLine("Witamy w naszym sklepie! Wprowadz odpowiednia cyfre, aby przejsc do danej funkcjonalnosci.");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Kupno");
                System.Console.WriteLine("2. Sprzedaz");
                UserInput=Convert.ToInt32(Console.ReadLine());
                
                if (UserInput==1)
                {
                    PrintList();
                }

                else if (UserInput==2)
                {

                }

                else
                {
                    System.Console.WriteLine("Wprowadzono zla liczbe!");
                }


                x++;
            }
        }
        static int Number()
        {
            return 2;
        }
        static void PrintList()
        {
                try
        {   // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader("ListaProduktow.txt"))
            {
            // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        }
    }
}
