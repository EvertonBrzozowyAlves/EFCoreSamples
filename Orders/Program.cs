using Microsoft.EntityFrameworkCore;
using Orders.Domain;
using Orders.ValueObjects;

using var db = new Orders.Data.ApplicationContext();

// var hasPendingMigrations = db.Database.GetPendingMigrations().Any();

var product = new Product
{
    Description = "Test Product",
    BarCode = "1234567891231",
    Price = 10m,
    ProductType = ProductTypeEnum.Resale,
    Active = true,
};

db.Products.Add(product); //Firt option 
// db.Set<Product>().Add(product); //Second option
// db.Entry(product).State = EntityState.Added; //Third option
// db.Add(product); //Fourth option

var affectedRows = db.SaveChanges();
