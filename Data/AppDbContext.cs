using System;
using Microsoft.EntityFrameworkCore;
using VMS_Hisham_El_Shiraida.Models;

namespace VMS_Hisham_El_Shiraida.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("VehicleInfo");
                entity.HasKey(e => e.VehicleId);
                entity.Property(e => e.VehicleId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, Make = "Ford F-150", Type = VehicleType.Truck, PurchaseDate = new DateTime(2021, 3, 15), Year = 2021, Price = 42500.00m },
                new Vehicle { VehicleId = 2, Make = "Toyota Camry", Type = VehicleType.Sedan, PurchaseDate = new DateTime(2020, 7, 22), Year = 2020, Price = 27800.00m },
                new Vehicle { VehicleId = 3, Make = "Honda Odyssey", Type = VehicleType.Van, PurchaseDate = new DateTime(2019, 11, 5), Year = 2019, Price = 33400.00m },
                new Vehicle { VehicleId = 4, Make = "Toyota RAV4", Type = VehicleType.SUV, PurchaseDate = new DateTime(2022, 1, 18), Year = 2022, Price = 36900.00m },
                new Vehicle { VehicleId = 5, Make = "Ford Mustang", Type = VehicleType.Coupe, PurchaseDate = new DateTime(2023, 6, 10), Year = 2023, Price = 48200.00m },
                new Vehicle { VehicleId = 6, Make = "Chevrolet Silverado", Type = VehicleType.Truck, PurchaseDate = new DateTime(2021, 8, 30), Year = 2021, Price = 45100.00m },
                new Vehicle { VehicleId = 7, Make = "Honda Civic", Type = VehicleType.Sedan, PurchaseDate = new DateTime(2022, 4, 12), Year = 2022, Price = 26500.00m },
                new Vehicle { VehicleId = 8, Make = "Chrysler Pacifica", Type = VehicleType.Van, PurchaseDate = new DateTime(2020, 9, 14), Year = 2020, Price = 35800.00m },
                new Vehicle { VehicleId = 9, Make = "Jeep Grand Cherokee", Type = VehicleType.SUV, PurchaseDate = new DateTime(2023, 2, 28), Year = 2023, Price = 51200.00m },
                new Vehicle { VehicleId = 10, Make = "Chevrolet Camaro", Type = VehicleType.Coupe, PurchaseDate = new DateTime(2022, 10, 3), Year = 2022, Price = 43700.00m },
                new Vehicle { VehicleId = 11, Make = "RAM 1500", Type = VehicleType.Truck, PurchaseDate = new DateTime(2024, 5, 20), Year = 2024, Price = 54900.00m }
            );
        }
    }
}
