using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.GitHub.OpenApiClient;
using Soenneker.GitHub.OpenApiClient.Models;
using Soenneker.GitHub.OpenApiClient.Repos.Item.Item.Subscription;
using Soenneker.GitHub.Repositories.Subscriptions.Abstract;

namespace Soenneker.GitHub.Repositories.Subscriptions;

/// <inheritdoc cref="IGitHubRepositoriesSubscriptionsUtil"/>
public sealed class GitHubRepositoriesSubscriptionsUtil : IGitHubRepositoriesSubscriptionsUtil
{
    private readonly ILogger<GitHubRepositoriesSubscriptionsUtil> _logger;
    private readonly IGitHubOpenApiClientUtil _gitHubClientUtil;

    public GitHubRepositoriesSubscriptionsUtil(ILogger<GitHubRepositoriesSubscriptionsUtil> logger, IGitHubOpenApiClientUtil gitHubClientUtil)
    {
        _logger = logger;
        _gitHubClientUtil = gitHubClientUtil;
    }

    public async ValueTask<RepositorySubscription?> GetStatus(string owner, string repo, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Getting subscription status for repository {Owner}/{Repo}", owner, repo);
            
            GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
            return await client.Repos[owner][repo].Subscription.GetAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting subscription status for repository {Owner}/{Repo}", owner, repo);
            throw;
        }
    }

    public async ValueTask<RepositorySubscription> Subscribe(string owner, string repo, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Subscribing to repository {Owner}/{Repo}", owner, repo);

            var requestBody = new SubscriptionPutRequestBody
            {
                Subscribed = true,
                Ignored = false
            };

            GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
            return await client.Repos[owner][repo].Subscription.PutAsync(requestBody, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error subscribing to repository {Owner}/{Repo}", owner, repo);
            throw;
        }
    }

    public async ValueTask Unsubscribe(string owner, string repo, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Unsubscribing from repository {Owner}/{Repo}", owner, repo);

            GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
            await client.Repos[owner][repo].Subscription.DeleteAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unsubscribing from repository {Owner}/{Repo}", owner, repo);
            throw;
        }
    }
}
