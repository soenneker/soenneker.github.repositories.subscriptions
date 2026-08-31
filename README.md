[![](https://img.shields.io/nuget/v/soenneker.github.repositories.subscriptions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.github.repositories.subscriptions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.repositories.subscriptions/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.github.repositories.subscriptions/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.github.repositories.subscriptions.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.github.repositories.subscriptions/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.repositories.subscriptions/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.github.repositories.subscriptions/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.GitHub.Repositories.Subscriptions

Read, enable, or remove the authenticated GitHub user's watch subscription for a repository.

## Installation

```bash
dotnet add package Soenneker.GitHub.Repositories.Subscriptions
```

## Configuration

```json
{
  "GH": {
    "Token": "github-token"
  }
}
```

The token identifies the user whose repository notification setting will be read or changed and needs access to the target repository.

## Registration

```csharp
services.AddGitHubRepositoriesSubscriptionsUtilAsSingleton();
```

Use `AddGitHubRepositoriesSubscriptionsUtilAsScoped()` for a scoped consumer.

## Usage

```csharp
RepositorySubscription? current = await subscriptions.GetStatus(
    "soenneker",
    "example-repository",
    cancellationToken);

RepositorySubscription watching = await subscriptions.Subscribe(
    "soenneker",
    "example-repository",
    cancellationToken);

await subscriptions.Unsubscribe(
    "soenneker",
    "example-repository",
    cancellationToken);
```

`Subscribe` sets `subscribed` to `true` and `ignored` to `false`, enabling watch notifications for the authenticated user. `Unsubscribe` removes that user's repository subscription.

These methods manage GitHub's repository watching/notification subscription. They do not manage webhooks, GitHub Sponsors, package subscriptions, or repository access.
