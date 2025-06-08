using System.Threading;
using System.Threading.Tasks;
using Soenneker.GitHub.OpenApiClient.Models;

namespace Soenneker.GitHub.Repositories.Subscriptions.Abstract;

/// <summary>
/// A utility for managing GitHub Repository Subscriptions
/// </summary>
public interface IGitHubRepositoriesSubscriptionsUtil
{
    /// <summary>
    /// Gets the subscription status for a repository
    /// </summary>
    /// <param name="owner">The owner of the repository</param>
    /// <param name="repo">The name of the repository</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The repository subscription status</returns>
    ValueTask<RepositorySubscription?> GetStatus(string owner, string repo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Subscribes to a repository
    /// </summary>
    /// <param name="owner">The owner of the repository</param>
    /// <param name="repo">The name of the repository</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The updated repository subscription status</returns>
    ValueTask<RepositorySubscription> Subscribe(string owner, string repo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Unsubscribes from a repository
    /// </summary>
    /// <param name="owner">The owner of the repository</param>
    /// <param name="repo">The name of the repository</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    ValueTask Unsubscribe(string owner, string repo, CancellationToken cancellationToken = default);
}
