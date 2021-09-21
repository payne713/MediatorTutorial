using Project.Domain.AggregateModels;
using System;
using System.Linq;

namespace Project.Domain.SeedWorks
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.AppUsers.Any())
                return;

            AppUser admin = new()
            {
                Id = Guid.NewGuid(),
                Name = "管理员",
                Account = "admin",
                Phone = "13912345678",
                Age = 18,
                Password = "123456",
                Gender = true,
                IsEnabled = true,
                Address = new Address("文化路街道", "郑州市", "河南省", "12345"),
                Email = "danvic.wang@yuiter.com",
            };

            context.AppUsers.Add(admin);
            context.SaveChanges();
        }
    }
}