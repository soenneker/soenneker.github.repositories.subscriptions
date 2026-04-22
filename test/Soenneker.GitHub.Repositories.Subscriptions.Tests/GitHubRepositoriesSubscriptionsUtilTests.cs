using Soenneker.GitHub.Repositories.Subscriptions.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.GitHub.Repositories.Subscriptions.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class GitHubRepositoriesSubscriptionsUtilTests : HostedUnitTest
{
    private readonly IGitHubRepositoriesSubscriptionsUtil _util;

    public GitHubRepositoriesSubscriptionsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGitHubRepositoriesSubscriptionsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
