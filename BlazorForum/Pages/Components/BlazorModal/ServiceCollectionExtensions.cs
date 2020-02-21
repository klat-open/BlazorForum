using Microsoft.Extensions.DependencyInjection;

namespace BlazorForum.Pages.Components.BlazorModal
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorModal(this IServiceCollection services)
        {
            return services.AddScoped<IBlazorModal, BlazorModalService>();
        }
    }
}
