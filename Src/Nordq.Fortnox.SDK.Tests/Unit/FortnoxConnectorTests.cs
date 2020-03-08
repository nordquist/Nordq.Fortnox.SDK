using Nordq.Fortnox.SDK.Exceptions;
using Xunit;

namespace Nordq.Fortnox.SDK.Tests.Unit
{
    public class FortnoxConnectorTests
    {
        [Fact]
        public void FortnoxConnector_ctor_EmptyClientSecretValidAccessToken_ConfigurationExceptionIsThrown()
        {
            //Arrange
            const string clientSecret = null;
            const string accessToken = "my-access-token";

            //Act & Assert
            var exception = Assert.Throws<ConfigurationException>(() => new FortnoxConnector(clientSecret, accessToken));
            Assert.NotNull(exception);
            Assert.Equal(nameof(clientSecret), exception.Key);
        }

        [Fact]
        public void FortnoxConnector_ctor_EmptyAccessTokenValidClientSecret_ConfigurationExceptionIsThrown()
        {
            //Arrange
            const string clientSecret = "my-client-secret";
            const string accessToken = null;

            //Act & Assert
            var exception = Assert.Throws<ConfigurationException>(() => new FortnoxConnector(clientSecret, accessToken));
            Assert.NotNull(exception);
            Assert.Equal(nameof(accessToken), exception.Key);
        }
    }
}
