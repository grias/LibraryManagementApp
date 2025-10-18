using LibraryManagementApp.Domain.Interfaces.Services;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Services;
using LibraryManagementApp.DataAccess.Repositories;

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

        builder.Services.AddSingleton<IBooksRepository, InMemoryBooksRepository>();
        builder.Services.AddTransient<IBooksService, BooksService>();

        builder.Services.AddSingleton<IAuthorsRepository, InMemoryAuthorsRepository>();
        builder.Services.AddTransient<IAuthorsService, AuthorsService>();

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
}
