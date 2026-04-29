using System;

namespace Shop.Common
{
    public class Phone : Product
    {
        public string Brand { get; set; }

        public override void Show()
        {
            Console.WriteLine($"{Name} ({Brand}) - {Price}");
        }
    }
}