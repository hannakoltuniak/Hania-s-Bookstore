﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HaniasBookstore.Models
{
    public class HaniasBookstoreDbContext : IdentityDbContext
    {
        public HaniasBookstoreDbContext(DbContextOptions<HaniasBookstoreDbContext> options) : base(options)
        {
        }

        public void UpdateBooks(List<Book> updatedBooks)
        {
            foreach (var updatedBook in updatedBooks)
            {
                var existingBook = Books.Find(updatedBook.Id);

                if (existingBook != null)
                {
                    Entry(existingBook).CurrentValues.SetValues(updatedBook);
                }
            }

            SaveChanges();
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
