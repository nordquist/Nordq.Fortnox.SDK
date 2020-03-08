using System.Threading.Tasks;
using Nordq.Fortnox.SDK.Services;
using Nordq.Fortnox.SDK.Tests.Infrastructure;
using Xunit;

namespace Nordq.Fortnox.SDK.Tests.Integration.Services
{
    [Collection("DefaultCollection")]
    public class CustomerServiceTests
    {
        private readonly TestContext _testContext;

        public CustomerServiceTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task GetAllCustomersAsync_ValidConfig_ValidDeserializedResultReturned()
        {
            //Arrange
            var clientSecret = _testContext.Configuration["FortnoxClientSecret"];
            var accessToken = _testContext.Configuration["FortnoxAccessToken"];
            var sut = new CustomerService(clientSecret, accessToken);

            //Act
            var result = await sut.GetAllCustomersAsync();

            //Assert
            Assert.NotNull(result);
        }
    }
}
