using Main.Application.Services.Implementations;
using Main.Application.Services.Interfaces;
using Main.Data.Repositories;
using Main.Domain.Interfaces;
using Main.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Main.IoC
{
    public static class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IAboutUsServices, AboutUsServices>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IUserRegisterService, UserRegisterService>();
            
        }
    }
}
