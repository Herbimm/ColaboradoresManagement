using ColaboradoresManagement.Domain.Interface.Service;
using ColaboradoresManagement.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaboradoresManagement.CrossCutting.DependencyInjection
{
    public static class DependencyInjectionService
    {
        public static void AddDependecyInjectionService(IServiceCollection services)
        {
            services.AddScoped<IGerenciarColaboradoresService, GerenciarColaboradoresService>();

        }

    }
}
