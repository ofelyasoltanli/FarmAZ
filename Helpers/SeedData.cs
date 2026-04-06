using FarmAZ.Data;
using FarmAZ.Entities;

namespace FarmAZ.Helpers;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Users.Any())
            return;

        var farmer = new User
        {
            FullName = "Fermer Ali",
            Email = "fermer@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            Role = "Farmer"
        };

        var customer = new User
        {
            FullName = "Alıcı Veli",
            Email = "alici@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            Role = "Customer"
        };

        context.Users.AddRange(farmer, customer);
        context.SaveChanges(); // ← əvvəlcə userləri saxla

        var products = new List<Product>
        {
            new Product
            {
                Name = "Pomidor",
                Description = "Təzə pomidor",
                Price = 2.5,
                City = "Bakı",
                Address = "Nərimanov",
                Latitude = 40.4093,
                Longitude = 49.8671,
                ImageUrl = "https://via.placeholder.com/150",
                UserId = farmer.Id  // ← farmer ID-si
            },
            new Product
            {
                Name = "Xiyar",
                Description = "Təzə xiyar",
                Price = 1.8,
                City = "Sumqayıt",
                Address = "Mərkəz",
                Latitude = 40.5855,
                Longitude = 49.6317,
                ImageUrl = "https://via.placeholder.com/150",
                UserId = farmer.Id  // ← farmer ID-si
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}