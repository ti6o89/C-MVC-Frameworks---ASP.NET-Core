﻿namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BookCategory> BooksInCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<BookCategory>()
                .HasKey(bk => new { bk.BookId, bk.CategoryId });

            builder
                .Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder
                .Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(bc => bc.Book)
                .HasForeignKey(bc => bc.BookId);

            builder
                .Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(bc => bc.Category)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
