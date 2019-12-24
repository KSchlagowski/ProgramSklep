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
            List<string> Names = new List<string>();
            List<float> Prices = new List<float>();

            int UserInput=0;
            int ProductsNumber=HowMany();
           

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
                                System.Console.WriteLine("Dostępne produkty:");
                                PrintCart(Names, Prices, Cart);  
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

                                Names = ProductsList();
                                Prices = PricesList();
                                PrintList(Names,Prices,ProductsNumber);

                                System.Console.WriteLine("---------------");
                                int UserInput3=0;
                                UserInput3=Convert.ToInt32(Console.ReadLine());

                                if (UserInput3==0)
                                {
                                    break;
                                }
                                else if (UserInput2>ProductsNumber)
                                {
                                    System.Console.WriteLine("Wprowadzono złą liczbę!");
                                }
                                else
                                {
                                    Cart.Add(UserInput3-1);
                                }




                            }
                        }  
                    }
                }


                //sprzedaż
                else if (UserInput==2)
                {
                    string UserInput2 = "";
                    string Name = "";
                    float Price = 0;

                    while (true)
                    {
                        System.Console.WriteLine();
                        System.Console.WriteLine("---------------");
                        System.Console.WriteLine("Jesteś w trybie przyjmowania nowego towaru. Aby z niego wyjść wprowadź 0.");
                        System.Console.WriteLine();
                        System.Console.WriteLine("Wpisz nazwę produktu: ");
                        UserInput2 = Console.ReadLine();

                        if (UserInput2=="0")
                        {
                            break;
                        }

                        else 
                        {
                            Name = UserInput2;
                            System.Console.WriteLine();
                            System.Console.WriteLine("Wpisz cenę produktu: ");
                            Price = float.Parse(Console.ReadLine());
                            
                            NewProduct(Name, Price);
                        }
                    }
                }
                



                //inna liczba
                else
                {
                    System.Console.WriteLine("Wprowadzono złą liczbę!");
                }

                
            }
        }
        

        //funkcja wyswietlajaca plik z lista dostepnych produktow w sklepie
        static void PrintList(List<string> Names, List<float> Prices, int Count) //Pobierana jest dlugosc listy, aby program sie nie wysypal przy roznych wielkosciach plikow
        {
            for (int i=0; i<Count ;i++)
            {
                System.Console.WriteLine(Names[i]+" "+Prices[i]);
            }
        }

        //funkcja wyswietlajaca koszyk i jego wartosc
        static void PrintCart(List<string> Names, List<float> Prices, List<int> Cart)
        {
            float Price=0;
            System.Console.WriteLine("W twoim koszyku znajdują się: ");
            
            for (int i=0; i<Cart.Count ; i++)
            {
                System.Console.WriteLine(Names[Cart[i]]);
                Price += Prices[Cart[i]];
            }

            System.Console.WriteLine("Łączna wartość koszyka: "+Price+" PLN");
        }


        //funkcja zliczajaca ilosc ilosc elementow w dwoch plikach i porownujaca otrzymany wynik
        static int HowMany()
        {
            int numberPro=0;
            try
            {
                using (StreamReader streamR = new StreamReader("Products.txt"))
                {
                    string line;
                    while ((line = streamR.ReadLine()) != null)
                    {
                        numberPro++;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Błąd w odczycie pliku Products.txt!");
                System.Console.WriteLine(e.Message);
            }

            int numberPri=0;
            try
            {
                using (StreamReader streamR = new StreamReader("Prices.txt"))
                {
                    string line;
                    while ((line = streamR.ReadLine()) != null)
                    {
                        numberPri++;
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Błąd w odczycie pliku Prices.txt!");
                System.Console.WriteLine(e.Message);
            }

            if (numberPro != numberPri)
            {
                System.Console.WriteLine("UWAGA! Niezgodna ilość danych w plikach Products.txt oraz Prices.txt!");
                numberPro=0;
            }
            return numberPro;
        }


        //funkcja tworzaca liste z nazwami produktow
        static List<string> ProductsList()
        {
            List<string> Products = new List<string>();
            try
            {
                using (StreamReader streamR = new StreamReader("Products.txt")) //true or false w Writerze to nadpisanie zawartosci
                {
                    
                    string line;
                    while ((line = streamR.ReadLine()) != null)
                    {
                        Products.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Błąd w odczycie pliku Products.txt!");
                System.Console.WriteLine(e.Message);
            }

            return Products;
        }

        //funkcja tworzaca liste z cenami produktow
        static List<float> PricesList()
        {
            List<float> Prices = new List<float>();
            try
            {
                using (StreamReader streamR = new StreamReader("Prices.txt")) //true or false w Writerze to nadpisanie zawartosci
                {
                    
                    string line;
                    while ((line = streamR.ReadLine()) != null)
                    {
                        Prices.Add(Convert.ToInt32(line));
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Błąd w odczycie pliku Prices.txt!");
                System.Console.WriteLine(e.Message);
            }

            return Prices;
        }

        //funkcja dodajaca nowe produkty
        static void NewProduct(string name, float price)
        {
            try
            {
                using (StreamWriter streamW1 = new StreamWriter(("Products.txt"), true))
                {
                    streamW1.WriteLine("");
                    streamW1.Write(name);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Błąd w odczycie pliku Products.txt!");
                System.Console.WriteLine(e.Message);
            }

            try
            {
                using (StreamWriter streamW2 = new StreamWriter(("Prices.txt"), true))
                {
                    streamW2.WriteLine("");
                    streamW2.Write(price);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Błąd w odczycie pliku Prices.txt!");
                System.Console.WriteLine(e.Message);
            }
        }
        
    }
}
