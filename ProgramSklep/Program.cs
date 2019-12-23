using System;
using System.IO;
using System.Collections.Generic;

namespace ProgramSklep
{
    class Program
    {
        static void Main(string[] args)
        {
            //zmienne
            List<int> Cart = new List<int>();
            int UserInput=0;
            int LastProduct=4;


            //menu
            
            while (true)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("---------------");
                System.Console.WriteLine("0. Wyjście.");
                System.Console.WriteLine("1. Kupno");
                System.Console.WriteLine("2. Sprzedaż");
                System.Console.WriteLine("---------------");

                UserInput = Convert.ToInt32(Console.ReadLine());
                
                if (UserInput==0)
                {
                    break;  
                }
                else if (UserInput==1)
                {
                    //system kupowania
                    while (true)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("---------------");
                        System.Console.WriteLine("0. Powrót do poprzedniego menu.");
                        System.Console.WriteLine("1. Wyświetlenie zawartości koszyka.");
                        System.Console.WriteLine("2. Przejście do płatności.");
                        System.Console.WriteLine("3. Sklep.");
                        System.Console.WriteLine("---------------");

                        int UserInput2=0;
                        UserInput2 = Convert.ToInt32(Console.ReadLine());

                        if (UserInput2==0)
                        {
                           break; 
                        }
                        //koszyk
                        else if (UserInput2==1)
                        {
                            int CartLen = Cart.Count;
                            if (CartLen == 0)
                            {
                                System.Console.WriteLine();
                                System.Console.WriteLine("---------------");
                                System.Console.WriteLine("Twój koszyk jest pusty.");
                                System.Console.WriteLine("---------------");
                            }
                            else
                            {
                                System.Console.WriteLine();
                                System.Console.WriteLine("---------------");
                                PrintCart(Cart);  
                                System.Console.WriteLine("---------------");
                            }
                        }
                        //platnosc
                        else if (UserInput2==2)
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("---------------");
                            System.Console.WriteLine("Ta opcja jest niedostępna w wersji DEMO programu.");
                            System.Console.WriteLine("---------------");
                        }
                        //sklep
                        else if (UserInput2==3)
                        {
                            while (true)
                            {
                                System.Console.WriteLine();
                                System.Console.WriteLine("---------------");
                                System.Console.WriteLine("Wpisując liczbę odpowiadającej danej rzeczy dodajesz ją do koszyka.");
                                System.Console.WriteLine("Cyfra 0 to powrót do poprzedniego menu.");
                                PrintList();
                                System.Console.WriteLine("---------------");
                                int UserInput3=0;
                                UserInput3=Convert.ToInt32(Console.ReadLine());

                                if (UserInput3==0)
                                {
                                    break;
                                }
                                else if (UserInput2>LastProduct)
                                {
                                    System.Console.WriteLine("Wprowadzono złą liczbę!");
                                }
                                else
                                {
                                    Cart.Add(UserInput3);
                                }



                            }
                        }  
                    }
                }





                //sprzedaż
                else if (UserInput==2)
                {

                }

                //inna liczba
                else
                {
                    System.Console.WriteLine("Wprowadzono złą liczbę!");
                }

                
            }
        }
        

        //funkcja wyswietlajaca plik z lista dostepnych produktow w sklepie
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

        //funkcja wyswietlajaca koszyk i jego wartosc
        static void PrintCart(List<int> Cart)
        {
            System.Console.WriteLine("W twoim koszyku znajdują się: ");
            foreach (int i in Cart)
            {
                if (i==1)
                {
                    System.Console.WriteLine("Stroik do saksofonu");
                }
                if (i==2)
                {
                    System.Console.WriteLine("Struny do gitary");
                }
                if (i==3)
                {
                    System.Console.WriteLine("Oliwka do tlokow");
                }
                if (i==4)
                {
                    System.Console.WriteLine("Kalafonia");
                }
            }

            float Price=0;
            foreach (int i in Cart)
            {
                if (i==1)
                {
                    Price+=15;
                }
                if (i==2)
                {
                    Price+=20;
                }
                if (i==3)
                {
                    Price+=26;
                }
                if (i==4)
                {
                    Price+=16;
                }
            }
            System.Console.WriteLine("Łączna wartość koszyka: "+Price+" PLN");
        }
    }
}
