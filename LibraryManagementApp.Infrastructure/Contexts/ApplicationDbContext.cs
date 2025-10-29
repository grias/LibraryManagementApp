using LibraryManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Infrastructure.Contexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        PopulateWithInitialSeedAuthorsTable(modelBuilder);
        PopulateWithInitialSeedBooksTable(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void PopulateWithInitialSeedBooksTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Title = "War and Peace", PublishedYear = 1869, AuthorId = 1 },
                    new Book { Id = 2, Title = "Anna Karenina", PublishedYear = 1877, AuthorId = 1 },
                    new Book { Id = 3, Title = "Crime and Punishment", PublishedYear = 1866, AuthorId = 2 },
                    new Book { Id = 4, Title = "The Brothers Karamazov", PublishedYear = 1880, AuthorId = 2 },
                    new Book { Id = 5, Title = "Eugene Onegin", PublishedYear = 1833, AuthorId = 3 },
                    new Book { Id = 6, Title = "The Captain's Daughter", PublishedYear = 1836, AuthorId = 3 },
                    new Book { Id = 7, Title = "The Master and Margarita", PublishedYear = 1967, AuthorId = 4 },
                    new Book { Id = 8, Title = "Heart of a Dog", PublishedYear = 1925, AuthorId = 4 },
                    new Book { Id = 9, Title = "The Cherry Orchard", PublishedYear = 1904, AuthorId = 5 },
                    new Book { Id = 10, Title = "Ward No. 6", PublishedYear = 1892, AuthorId = 5 },
                    new Book { Id = 11, Title = "Pride and Prejudice", PublishedYear = 1813, AuthorId = 6 },
                    new Book { Id = 12, Title = "Emma", PublishedYear = 1815, AuthorId = 6 },
                    new Book { Id = 13, Title = "Oliver Twist", PublishedYear = 1838, AuthorId = 7 },
                    new Book { Id = 14, Title = "Great Expectations", PublishedYear = 1861, AuthorId = 7 },
                    new Book { Id = 15, Title = "The Trial", PublishedYear = 1925, AuthorId = 8 },
                    new Book { Id = 16, Title = "The Castle", PublishedYear = 1926, AuthorId = 8 },
                    new Book { Id = 17, Title = "1984", PublishedYear = 1949, AuthorId = 9 },
                    new Book { Id = 18, Title = "Animal Farm", PublishedYear = 1945, AuthorId = 9 },
                    new Book { Id = 19, Title = "One Hundred Years of Solitude", PublishedYear = 1967, AuthorId = 10 },
                    new Book { Id = 20, Title = "The Autumn of the Patriarch", PublishedYear = 1975, AuthorId = 10 }
                );
    }

    private static void PopulateWithInitialSeedAuthorsTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
                    new Author { Id = 1, Name = "Lev Tolstoy", DateOfBirth = new DateOnly(1828, 9, 9) },
                    new Author { Id = 2, Name = "Fyodor Dostoevsky", DateOfBirth = new DateOnly(1821, 11, 11) },
                    new Author { Id = 3, Name = "Alexander Pushkin", DateOfBirth = new DateOnly(1799, 6, 6) },
                    new Author { Id = 4, Name = "Mikhail Bulgakov", DateOfBirth = new DateOnly(1891, 5, 15) },
                    new Author { Id = 5, Name = "Anton Chekhov", DateOfBirth = new DateOnly(1860, 1, 29) },
                    new Author { Id = 6, Name = "Jane Austen", DateOfBirth = new DateOnly(1775, 12, 16) },
                    new Author { Id = 7, Name = "Charles Dickens", DateOfBirth = new DateOnly(1812, 2, 7) },
                    new Author { Id = 8, Name = "Franz Kafka", DateOfBirth = new DateOnly(1883, 7, 3) },
                    new Author { Id = 9, Name = "George Orwell", DateOfBirth = new DateOnly(1903, 6, 25) },
                    new Author { Id = 10, Name = "Gabriel Garcia Marquez", DateOfBirth = new DateOnly(1927, 3, 6) }
                );
    }
}
