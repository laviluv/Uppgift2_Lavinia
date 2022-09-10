// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Uppgift2_Lavinia
{


    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Skriv in produktdata med Enter, avbryt med q");

            //  entries = new Entries();

            //List<Entries> entries = new List<Entries>();
            var entries = new List<Tuple<string, string, double>>();
            // int index = 0;



            //Produktlista
            List<Product> produkter = new List<Product>();
            //Categorilista
            List<Category> cats = new List<Category>();
            //Prislista
            List<Price> priser = new List<Price>();

            string Msg1 = $"Du angav att du ar klar med inmatningen 1.";
            string Msg2 = $"Du angav att du ar klar med inmatningen 2.";




            int index = 0;

            while (true)
            {


                Console.WriteLine("Skriv in en produkt: ");
                string article = Console.ReadLine();
                if (CheckExit(article) == false)
                {
                    Console.WriteLine(Msg1);
                    break;
                }

                Console.WriteLine("Skriv in ett kategori: ");
                string cat = Console.ReadLine();
                if (CheckExit(cat) == false)
                {
                    Console.WriteLine(Msg2);
                    break;
                }

                Console.WriteLine("Skriv in ett pris (0.00): ");
                string price = Console.ReadLine();

                if (CheckPrice(price.ToString()) == true)
                {

                    try
                    {

                        //  AddProductsToList(entries, article, cat, price);

                        ////Individuella klasserna
                        Product nyProdukt = new Product(index, article);
                        produkter.Add(nyProdukt);

                        Category nyCat = new Category(index, cat);
                        cats.Add(nyCat);

                        bool parseDouble = Double.TryParse(price, out double value);
                        if (parseDouble)
                        {
                            Price nyPrice = new Price(index, value);
                            priser.Add(nyPrice);

                        }
                        Console.WriteLine($"***** Produkt {index} tillagd. Ange fler eller avsluta med 'q' *****");
                        index += 1;

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Produktpris ska vara i sifferformat: 0.00 {ex}");
                        //break;

                    }


                }





            }

            if (produkter.Count != 0)
            {


                PresentEntries(produkter, cats, priser);
            }
        }

        private static void PresentEntries(List<Product> produkter, List<Category> cats, List<Price> priser)
        {
            Console.WriteLine("Produkterna sorterade efter pris (med sammanfattning) MED KLASSER");

            Console.WriteLine($"Produkt".PadRight(10) + "Kategory".ToString().PadRight(10) + "Pris");
            double totals = 0.00;


            var result = from d1 in produkter
                         join d2 in cats on d1.Id equals d2.Id
                         select new { d1.Article, d2.Cat, d1.Id } into merged
                         join d3 in priser on merged.Id equals d3.Id
                         select new { merged.Article, merged.Cat, d3.Pris };



            //Sort by price
            result = result.OrderBy(result => result.Pris).ToList();

            //Present
            foreach (var res in result)
            {
                Console.WriteLine(res.Article.PadRight(10) + res.Cat.PadRight(10) + res.Pris);
                totals += res.Pris;
            }

            Console.WriteLine("____________________________________________________");
            Console.WriteLine(" ".PadRight(10) + "SUMMA SUMMARUM *********: ".PadRight(10) + totals);

            Console.WriteLine("-------------------------------------------------------");


        }

        private static bool CheckExit(string input)
        {
            if (input.ToLower().Contains("q"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool CheckPrice(string input)
        {

            string pattern = @"^[0-9].+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);


        }


    }
}



