using Microsoft.EntityFrameworkCore;
using NarushPDD.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NarushPDD.InfrastructureServices.Gateways.Database
{
    public class PDDContext : DbContext
    {
        public DbSet<RoadPDD> RoadPDDs { get; set; }

        public PDDContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoadPDD>().HasData(
                new
  {
                    Id = 1L,
                    Data = "20.01.2013",
                    RecordedV = "Общее количество зафиксированных нарушений - 5374",
                    RegisteredV = "Общее количество оформленных - 2440"


                },
                new
                {
                    Id = 2L,
                    Data = "21.01.2013",
                    RecordedV = "Общее количество зафиксированных нарушений - 25312",
                    RegisteredV = "Общее количество оформленных - 1551"

                },
                new
                {
                    Id = 3L,
                    Data = "22.01.2013",
                    RecordedV = "Общее количество зафиксированных нарушений - 29132",
                    RegisteredV = "Общее количество оформленных - 2672"
                }
            );
        }
    }
}
