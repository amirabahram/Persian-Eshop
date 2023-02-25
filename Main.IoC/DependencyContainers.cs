using Main.Domain.Interfaces;
using Main.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.IoC
{
    public static class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFaqRepository, FaqRepository>();
        }
    }
}
