﻿using ConsoleLibrary.Entitys;
using Microsoft.EntityFrameworkCore;
namespace ConsoleLibrary
{
    public class ConsoleLibraryContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public ConsoleLibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ASROCK-DESKTOP; Database=library;Trusted_Connection=Yes;TrustServerCertificate=true;");
        }
    }
}