using System.Globalization;
using System.Collections.Generic;

namespace Teste.Entities
{
    internal class Product
    {

        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
