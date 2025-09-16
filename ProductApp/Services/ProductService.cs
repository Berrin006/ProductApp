using System;
using System.Collections.Generic;

namespace ProductApp
{
    public class ProductService
    {
        public List<Product> Products { get; private set; } = new List<Product>();

        public void AddProduct(string name, decimal price)
        {
            var product = new Product(name, price);
            Products.Add(product);
        }

        public void DisplayProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("Inga produkter finns.");
                return;
            }

            Console.WriteLine("Produkter:");
            foreach (var product in Products)
            {
                Console.WriteLine($"ID: {product.Id}, Namn: {product.Name}, Pris: {product.Price} kr");
            }
        }
    }
}
