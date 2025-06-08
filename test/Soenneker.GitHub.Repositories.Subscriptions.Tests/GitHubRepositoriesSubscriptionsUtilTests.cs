using Soenneker.GitHub.Repositories.Subscriptions.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.GitHub.Repositories.Subscriptions.Tests;

[Collection("Collection")]
public sealed class GitHubRepositoriesSubscriptionsUtilTests : FixturedUnitTest
{
    private readonly IGitHubRepositoriesSubscriptionsUtil _util;

    public GitHubRepositoriesSubscriptionsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGitHubRepositoriesSubscriptionsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
