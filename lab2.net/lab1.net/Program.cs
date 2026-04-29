using System;
using System.Linq;
using System.Threading.Tasks;
using Shop.Common;

var service = new AsyncCrudService<Product>();

// створення 1000 об'єктів паралельно
Parallel.For(0, 1000, async i =>
{
    var product = Product.CreateNew();
    await service.CreateAsync(product);
});

// читаємо всі
var all = await service.ReadAllAsync();

// LINQ
var min = all.Min(x => x.Price);
var max = all.Max(x => x.Price);
var avg = all.Average(x => x.Price);

Console.WriteLine($"Min: {min}");
Console.WriteLine($"Max: {max}");
Console.WriteLine($"Avg: {avg}");

// зберігаємо
await service.SaveAsync();