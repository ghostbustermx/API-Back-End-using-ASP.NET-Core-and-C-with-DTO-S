using TenantApplicationCRUD.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace TenantApplicationCRUD.API.DbContexts
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
          : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<TenantPersonnel> TenantPersonnels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Gender>().HasData(
                new Gender()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Male"
                },
                new Gender()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Female"
                }
                );

            modelBuilder.Entity<TenantPersonnel>().HasData(
               new TenantPersonnel
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   GenderId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   FirstName = "TEST1",
                   MiddleName = "TEST1_1",
                   LastName = "TEST1_1_1",
                   NickName = "TEST1_1_1_1"
               },
               new TenantPersonnel
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   GenderId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   FirstName = "TEST2",
                   MiddleName = "TEST2_2",
                   LastName = "TEST2_2_2",
                   NickName = "TEST2_2_2_2"
               },
               new TenantPersonnel
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   GenderId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   FirstName = "TEST3",
                   MiddleName = "TEST3_3",
                   LastName = "TEST3_3_3",
                   NickName = "TEST3_3_3_3"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
