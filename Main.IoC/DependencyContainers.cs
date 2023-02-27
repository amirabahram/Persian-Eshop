using Main.Domain.Interfaces;
using Main.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Main.Application.Services.Implementations;
using Main.Application.Services.Interfaces;
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
            services.AddScoped<IFaqService, FaqService>();
        }
    }
}
