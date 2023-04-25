using LogicLayer;
using DataLayer;

namespace ApiLayer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var angularCORSPolicy = "AllowAngularFE";
        builder.Services.AddCors(options => {
            options.AddPolicy(name: angularCORSPolicy,
                policy => {
                    policy.WithOrigins("https://localhost:7059")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                }
            );
        });

        // Adding Scoped Services
        builder.Services.AddScoped<ITodoListService, TodoListService>();
        builder.Services.AddScoped<ITodoListData, TodoListData>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors(angularCORSPolicy);

        app.MapControllers();

        app.Run();
    }
}
