using LibraryManagementApp.Domain.Interfaces.Services;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Services;
using LibraryManagementApp.DataAccess.Repositories;
using LibraryManagementApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        RegisterRepositories(builder);
        RegisterServices(builder);
        RegisterDbContext(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void RegisterRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IBooksRepository, InMemoryBooksRepository>();
        builder.Services.AddSingleton<IAuthorsRepository, InMemoryAuthorsRepository>();
    }

    private static void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBooksService, BooksService>();
        builder.Services.AddTransient<IAuthorsService, AuthorsService>();
    }

    private static void RegisterDbContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}
