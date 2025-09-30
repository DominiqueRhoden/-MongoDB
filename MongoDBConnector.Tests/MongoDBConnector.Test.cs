using Xunit;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using System.Threading.Tasks;

namespace MongoDBConnector.Tests
{
    public class MongoDBConnectorTests
    {
        [Fact]
        public async Task Ping_ShouldReturnTrue_WhenMongoIsRunning()
        {
            var mongoContainer = new TestcontainersBuilder<TestcontainersContainer>()
                .WithImage("mongo:6.0")
                .WithPortBinding(27017, 27017)
                .Build();

            await mongoContainer.StartAsync();

            var connector = new MongoDBConnector("mongodb://localhost:27017");
            Assert.True(connector.Ping());

            await mongoContainer.StopAsync();
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenConnectionFails()
        {
            var connector = new MongoDBConnector("mongodb://invalid:27017");
            Assert.False(connector.Ping());
        }

    }
}
