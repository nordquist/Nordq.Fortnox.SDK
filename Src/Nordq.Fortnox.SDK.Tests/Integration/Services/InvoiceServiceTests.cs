using System.Threading.Tasks;
using Nordq.Fortnox.SDK.Services;
using Nordq.Fortnox.SDK.Tests.Infrastructure;
using Xunit;

namespace Nordq.Fortnox.SDK.Tests.Integration.Services
{
    [Collection("DefaultCollection")]
    public class InvoiceServiceTests
    {
        private readonly TestContext _testContext;

        public InvoiceServiceTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task GetAllInvoicesAsync_ValidConfig_ValidDeserializedResultReturned()
        {
            //Arrange
            var clientSecret = _testContext.Configuration["FortnoxClientSecret"];
            var accessToken = _testContext.Configuration["FortnoxAccessToken"];
            var sut = new InvoiceService(clientSecret, accessToken);

            //Act
            var result = await sut.GetAllInvoicesAsync();

            //Assert
            Assert.NotNull(result);
        }
    }
}