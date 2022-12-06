using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using University.BLL;
using University.BLL.Mapping;
using University.BLL.Services;
using University.BLL.Services.Contracts;
using University.DAL;
using University.DAL.DataContext;
using University.DAL.Repositories;
using University.DAL.Repositories.Contracts;

namespace University.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDalServices();
            builder.Services.AddBllServices();
            //builder.Services.AddScoped(typeof(IRepository<>), typeof(XmlRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}