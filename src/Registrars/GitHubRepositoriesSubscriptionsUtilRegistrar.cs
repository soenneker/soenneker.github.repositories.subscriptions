using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.GitHub.ClientUtil.Registrars;
using Soenneker.GitHub.Repositories.Subscriptions.Abstract;

namespace Soenneker.GitHub.Repositories.Subscriptions.Registrars;

/// <summary>
/// A utility for managing GitHub Repository Subscriptions
/// </summary>
public static class GitHubRepositoriesSubscriptionsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGitHubRepositoriesSubscriptionsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGitHubRepositoriesSubscriptionsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGitHubOpenApiClientUtilAsSingleton().TryAddSingleton<IGitHubRepositoriesSubscriptionsUtil, GitHubRepositoriesSubscriptionsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IGitHubRepositoriesSubscriptionsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGitHubRepositoriesSubscriptionsUtilAsScoped(this IServiceCollection services)
    {
        services.AddGitHubOpenApiClientUtilAsSingleton().TryAddScoped<IGitHubRepositoriesSubscriptionsUtil, GitHubRepositoriesSubscriptionsUtil>();

        return services;
    }
}
