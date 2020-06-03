using Microsoft.EntityFrameworkCore;
using Bridges.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.InfrastructureServices.Gateways.Database
{
    public class BridgesContext : DbContext
    {
        public DbSet<BridgesPoint> BridgesPoints { get; set; }

        public BridgesContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BridgesPoint>().HasData(
                new
                {
                    Id = 1L,
                    Name = "Мост пешеходный «1905 года»",
                    Location = "Дружинниковская улица",
                    CrossRiver = "пруд в парке стадиона Красная Пресня",
                    Year = "1981"
                },
                new
                {
                    Id = 2L, 
                    Name = "Мост пешеходный «Андреевский»",
                    Location = "1-я Фрунзенская улица",
                    CrossRiver = "река Москва",
                    Year = "2000"

                },
                new
                {
                    Id = 3L,
                    Name = "Мост пешеходный «Балочный»",
                    Location = "улица Пырьева, дом 24",
                    CrossRiver = "река Сетунь", 
                    Year = "1956"

                },
                new
                {
                    Id = 4L, 
                    Name = "Мост пешеходный «Бауманский-1»",
                    Location = "городок имени Баумана",
                    CrossRiver = "пруд Серебряно-Виноградный",
                    Year = "1964"
 
                }
            );
        }
    }
}
