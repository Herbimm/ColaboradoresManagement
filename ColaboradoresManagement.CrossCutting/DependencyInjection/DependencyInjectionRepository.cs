using ColaboradoresManagement.CrossCutting.Utis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColaboradoresManagement.Repository.Context;

namespace ColaboradoresManagement.CrossCutting.DependencyInjection
{
    public static class DependencyInjectionRepository
    {
        public static void AddDependencyInjectionRepository(IServiceCollection services, ConfigurationRepository configurationRepository) 
        {
            services.AddSingleton(configurationRepository);
            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(configurationRepository.ConnectionString));
        }
    }
}
