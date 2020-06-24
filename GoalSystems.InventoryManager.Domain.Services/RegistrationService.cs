using Microsoft.Extensions.DependencyInjection;

namespace GoalSystems.InventoryManager.Domain.Services
{
    public static class RegistrationService
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IInventoryService, InventoryService>();
            return Infrastructure.Services.RegistrationService.AddRepositories(services);
        }
    }
}
