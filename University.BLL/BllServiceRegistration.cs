using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Repositories.Contracts;
using University.DAL.Repositories;
using University.BLL.Services.Contracts;
using University.BLL.Services;

namespace University.BLL
{
    public static class BllServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentManager>();
            
            return services;
        }
    }
}
