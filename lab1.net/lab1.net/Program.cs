using System;
using Shop.Common;

var service = new CrudService<Phone>();

var phone1 = new Phone
{
    Name = "iPhone",
    Price = 1000,
    Brand = "Apple"
};

var phone2 = new Phone
{
    Name = "Galaxy",
    Price = 800,
    Brand = "Samsung"
};

// CREATE
service.Create(phone1);
service.Create(phone2);

// READ ALL
foreach (var item in service.ReadAll())
{
    item.Show();
}

// UPDATE
phone1.Price = 900;
service.Update(phone1);

Console.WriteLine("After update:");
foreach (var item in service.ReadAll())
{
    item.Show();
}

// DELETE
service.Remove(phone2);

Console.WriteLine("After delete:");
foreach (var item in service.ReadAll())
{
    item.Show();
}

// EVENT
var ev = new EventExample();
ev.OnCreate += () => Console.WriteLine("Created!");
ev.Create();

// EXTENSION
phone1.Print();

Console.WriteLine("Total created: " + CrudService<Phone>.Count);