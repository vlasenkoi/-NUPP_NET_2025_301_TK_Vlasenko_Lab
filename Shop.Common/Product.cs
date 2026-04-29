using System;

namespace Shop.Common
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }

        // 🔥 ДОДАЙ ЦЕ
        public virtual void Show()
        {
            Console.WriteLine($"{Name} - {Price}");
        }

        public static Product CreateNew()
        {
            var rnd = new Random();
            return new Product
            {
                Name = "Product_" + rnd.Next(1, 1000),
                Price = rnd.Next(100, 2000)
            };
        }
    }
}