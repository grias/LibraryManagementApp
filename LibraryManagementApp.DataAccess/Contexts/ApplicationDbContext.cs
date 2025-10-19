using LibraryManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.DataAccess.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData([
                new Book() {Id = 1, Title = "Three little pigs", AuthorId = 1 , PublishedYear = 2007},
                new Book() {Id = 2, Title = "The lord of the rings", AuthorId = 2 , PublishedYear = 1954},
                new Book() {Id = 3, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 3 , PublishedYear = 1997},
                new Book() {Id = 4, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 3 , PublishedYear = 1898},
            ]);

        modelBuilder.Entity<Author>().HasData([
                new Author() {Id = 1, Name = "Unknown author"},
                new Author() {Id = 2, Name = "J. R. R. Tolkien", DateOfBirth = new DateOnly(1892, 1, 3)},
                new Author() {Id = 3, Name = "J. K. Rowling", DateOfBirth = new DateOnly(1965, 7, 31)},
            ]);

        base.OnModelCreating(modelBuilder);
    }
}
