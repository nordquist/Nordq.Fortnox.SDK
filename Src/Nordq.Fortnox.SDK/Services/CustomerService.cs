using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nordq.Fortnox.SDK.Client;
using Nordq.Fortnox.SDK.Extensions;
using Nordq.Fortnox.SDK.Interfaces;
using Nordq.Fortnox.SDK.Models;

namespace Nordq.Fortnox.SDK.Services
{
    public class CustomerService : ICustomerService
    {
        private const string Path = "customers";
        private readonly RestClient _restClient;

        public CustomerService(string clientSecret, string accessToken)
        {
            _restClient = new RestClient(new ApiHttpSettings(), clientSecret, accessToken);
        }

        public CustomerService(ApiHttpSettings apiHttpSettings, string clientSecret, string accessToken)
        {
            _restClient = new RestClient(apiHttpSettings, clientSecret, accessToken);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var list = new List<Customer>();
            var responseModel = await _restClient.GetAsync<FortnoxCustomerResponseModel>(Path);

            list.AddRange(responseModel.Customers);

            if (!responseModel.MetaInformation.Continue())
                return responseModel.Customers;

            if(!int.TryParse(responseModel.MetaInformation.CurrentPage, out var currentPageNumber))
                throw new ArgumentException($"Could not parse '{responseModel.MetaInformation?.CurrentPage}' to int32");

            var nextPageResponseModel = await _restClient.GetAsync<FortnoxCustomerResponseModel>(Path, page: currentPageNumber++);
            list.AddRange(nextPageResponseModel.Customers);
            while (responseModel.MetaInformation.Continue())
            {
                currentPageNumber += 1;
                nextPageResponseModel = await _restClient.GetAsync<FortnoxCustomerResponseModel>(Path, page: currentPageNumber);
                list.AddRange(nextPageResponseModel.Customers);
            }
            return list;
        }
    }
}
