using System;

namespace ProductApp.Models
{
    public class Product(string name, decimal price)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
    }
}
