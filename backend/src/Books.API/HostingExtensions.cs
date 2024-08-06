using Books.API.Filters;
using Books.Application.UseCases.Author.Create;
using Books.Domain.Interfaces.Commands;
using Books.Domain.Interfaces.Queries;
using Books.Persistence;
using Books.Persistence.Commands;
using Books.Persistence.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Books.API
{
    public static class HostingExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BooksDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("BooksManagement")));

            builder.Services.AddScoped(typeof(ICommandBase<>), typeof(BaseCommand<>));
            builder.Services.AddScoped(typeof(IQueryBase<>), typeof(BaseQuery<>));
            builder.Services.AddScoped(typeof(IBookQuery), typeof(BookQuery));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCommand).Assembly));

            builder.Services.AddScoped<ExceptionFilter>();

            return builder;
        }
    }
}
