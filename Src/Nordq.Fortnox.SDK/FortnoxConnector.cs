using Nordq.Fortnox.SDK.Exceptions;
using Nordq.Fortnox.SDK.Interfaces;
using Nordq.Fortnox.SDK.Services;

namespace Nordq.Fortnox.SDK
{
    /// <summary>
    /// Setup by providing Fortnox; Client-Secret and Access-Token
    /// Optionally provide an alternative <c>ApiHttpSettings</c>
    /// </summary>
    public class FortnoxConnector
    {
        public ICustomerService CustomerService { get; }
        public IInvoiceService InvoiceService { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="clientSecret">Fortnox Client-Secret (mandatory)</param>
        /// <param name="accessToken">Fortnox Access-Token (mandatory)</param>
        public FortnoxConnector(string clientSecret, string accessToken)
        {
            VerifyConfiguration(clientSecret, accessToken);
            CustomerService = new CustomerService(clientSecret, accessToken);
            InvoiceService = new InvoiceService(clientSecret, accessToken);
        }

        /// <summary>
        /// Constructor overload with ApiHttpSettings parameter
        /// </summary>
        /// <param name="apiHttpSettings">ApiHttpSettings</param>
        /// <param name="clientSecret">Fortnox Client-Secret (mandatory)</param>
        /// <param name="accessToken">Fortnox Access-Token (mandatory)</param>
        public FortnoxConnector(ApiHttpSettings apiHttpSettings, string clientSecret, string accessToken)
        {
            VerifyConfiguration(clientSecret, accessToken);
            CustomerService = new CustomerService(apiHttpSettings, clientSecret, accessToken);
        }

        private void VerifyConfiguration(string clientSecret, string accessToken)
        {
            if (string.IsNullOrWhiteSpace(clientSecret))
                throw new ConfigurationException(nameof(clientSecret), "Client-Secret must be set");
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ConfigurationException(nameof(accessToken), "Access-Token must be set");
        }
    }
}
