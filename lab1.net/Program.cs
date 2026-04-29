using Shop.Infrastructure;
using Shop.Infrastructure.Models;
using System.Linq;

try
{
    var repo = new ProductRepository();

    // CREATE
    await repo.AddAsync(new ProductModel { Name = "iPhone", Price = 1000 });
    await repo.AddAsync(new ProductModel { Name = "Samsung", Price = 800 });

    Console.WriteLine("All products:");
    var products = await repo.GetAllAsync();

    foreach (var p in products)
    {
        Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}");
    }

    // UPDATE
    var first = products.First();
    first.Price = 900;
    await repo.Update(first);

    Console.WriteLine("\nAfter update:");
    var updated = await repo.GetAllAsync();
    foreach (var p in updated)
    {
        Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}");
    }

    // DELETE
    await repo.Delete(first);

    Console.WriteLine("\nAfter delete:");
    var afterDelete = await repo.GetAllAsync();
    foreach (var p in afterDelete)
    {
        Console.WriteLine($"{p.Id}: {p.Name} - {p.Price}");
    }
}
catch (Exception ex)
{
    Console.WriteLine("ERROR:");
    Console.WriteLine(ex.Message);

    if (ex.InnerException != null)
    {
        Console.WriteLine("INNER ERROR:");
        Console.WriteLine(ex.InnerException.Message);
    }
}

Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();