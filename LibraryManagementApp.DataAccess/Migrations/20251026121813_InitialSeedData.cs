using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateOnly(1828, 9, 9), "Lev Tolstoy" },
                    { 2, new DateOnly(1821, 11, 11), "Fyodor Dostoevsky" },
                    { 3, new DateOnly(1799, 6, 6), "Alexander Pushkin" },
                    { 4, new DateOnly(1891, 5, 15), "Mikhail Bulgakov" },
                    { 5, new DateOnly(1860, 1, 29), "Anton Chekhov" },
                    { 6, new DateOnly(1775, 12, 16), "Jane Austen" },
                    { 7, new DateOnly(1812, 2, 7), "Charles Dickens" },
                    { 8, new DateOnly(1883, 7, 3), "Franz Kafka" },
                    { 9, new DateOnly(1903, 6, 25), "George Orwell" },
                    { 10, new DateOnly(1927, 3, 6), "Gabriel Garcia Marquez" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1869, "War and Peace" },
                    { 2, 1, 1877, "Anna Karenina" },
                    { 3, 2, 1866, "Crime and Punishment" },
                    { 4, 2, 1880, "The Brothers Karamazov" },
                    { 5, 3, 1833, "Eugene Onegin" },
                    { 6, 3, 1836, "The Captain's Daughter" },
                    { 7, 4, 1967, "The Master and Margarita" },
                    { 8, 4, 1925, "Heart of a Dog" },
                    { 9, 5, 1904, "The Cherry Orchard" },
                    { 10, 5, 1892, "Ward No. 6" },
                    { 11, 6, 1813, "Pride and Prejudice" },
                    { 12, 6, 1815, "Emma" },
                    { 13, 7, 1838, "Oliver Twist" },
                    { 14, 7, 1861, "Great Expectations" },
                    { 15, 8, 1925, "The Trial" },
                    { 16, 8, 1926, "The Castle" },
                    { 17, 9, 1949, "1984" },
                    { 18, 9, 1945, "Animal Farm" },
                    { 19, 10, 1967, "One Hundred Years of Solitude" },
                    { 20, 10, 1975, "The Autumn of the Patriarch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
