using Xunit;

namespace ZlowZebra.Tests.Unit
{
    public class TestContext : IUseFixture<FixtureSetup>
    {
        public void SetFixture(FixtureSetup data)
        {
            throw new System.NotImplementedException();
        }

        [Fact]
        public void WebServerExtensionTests()
        {
             
        }
    }

    public class FixtureSetup
    {
        
    }
}