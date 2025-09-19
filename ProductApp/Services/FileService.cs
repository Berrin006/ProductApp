using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProductApp.Services
{
    public class FileService(string filePath)
    {
        private readonly string _filePath = filePath;

        public void SaveProducts(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
            Console.WriteLine($"Produkter sparade till {_filePath}");
        }

        public List<Product> LoadProducts()
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Filen finns inte.");
                return [];
            }

            var json = File.ReadAllText(_filePath);
            var productsFromFile = JsonSerializer.Deserialize<List<Product>>(json);
            Console.WriteLine($"Lade till {productsFromFile?.Count ?? 0} produkter från filen.");
            return productsFromFile ?? [];
        }
    }
}
