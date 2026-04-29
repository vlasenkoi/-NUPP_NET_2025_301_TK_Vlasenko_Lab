using System;

namespace Shop.Common
{
    public static class Extensions
    {
        public static void Print(this Product product)
        {
            Console.WriteLine(product.Name);
        }
    }
}