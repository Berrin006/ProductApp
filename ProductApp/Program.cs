using ProductApp.Services;
using System;

namespace ProductApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();
            var fileService = new FileService("products.json");

            while (true)
            {
                Console.WriteLine("1. Lägg till produkt");
                Console.WriteLine("2. Visa produkter");
                Console.WriteLine("3. Läs produkter från fil");
                Console.WriteLine("4. Spara produkter till fil");
                Console.WriteLine("5. Avsluta");
                Console.WriteLine(); 

                Console.Write("Välj ett alternativ: ");
                var input = Console.ReadLine();
                Console.WriteLine(); 

                switch (input)
                {
                    case "1":
                        Console.Write("Ange produktnamn: ");
                        string name = Console.ReadLine()!;
                        Console.WriteLine();

                        Console.Write("Ange pris: ");
                        Console.WriteLine();

                        try
                        {
                            decimal price = decimal.Parse(Console.ReadLine()!);
                            productService.AddProduct(name, price);

                            Console.WriteLine("Produkten har lagts till.");
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Ogiltigt pris.");
                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        productService.DisplayProducts();
                        Console.WriteLine();
                        break;

                    case "3":
                        productService.Products.AddRange(fileService.LoadProducts());
                        Console.WriteLine("Produkter har lästs in från fil.");
                        Console.WriteLine();
                        break;

                    case "4":
                        fileService.SaveProducts(productService.Products);
                        Console.WriteLine("Produkter har sparats till fil.");
                        Console.WriteLine();
                        break;

                    case "5":
                        Console.WriteLine("Avslutar programmet...");
                        Console.WriteLine();
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
