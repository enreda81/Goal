using GoalSystems.InventoryManager.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GoalSystems.InventoryManager.Infrastructure.Services
{
    public static class RegistrationService
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {            
            services.AddSingleton<IElementRepository, ElementRepository>();
            return services;
        }
    }
}
