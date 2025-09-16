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
                Console.WriteLine("\n1. Lägg till produkt");
                Console.WriteLine("2. Visa produkter");
                Console.WriteLine("3. Läs produkter från fil");
                Console.WriteLine("4. Spara produkter till fil");
                Console.WriteLine("5. Avsluta");
                Console.Write("Välj ett alternativ: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Ange produktnamn: ");
                        string name = Console.ReadLine();
                        Console.Write("Ange pris: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            productService.AddProduct(name, price);
                            Console.WriteLine("Produkten har lagts till.");
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt pris.");
                        }
                        break;

                    case "2":
                        productService.DisplayProducts();
                        break;

                    case "3":
                        var loadedProducts = fileService.LoadProducts();
                        productService.Products.AddRange(loadedProducts);
                        break;

                    case "4":
                        fileService.SaveProducts(productService.Products);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
        }
    }
}
