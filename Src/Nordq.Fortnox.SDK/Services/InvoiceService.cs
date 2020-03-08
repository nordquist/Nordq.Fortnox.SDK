using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nordq.Fortnox.SDK.Client;
using Nordq.Fortnox.SDK.Extensions;
using Nordq.Fortnox.SDK.Interfaces;
using Nordq.Fortnox.SDK.Models;

namespace Nordq.Fortnox.SDK.Services
{
    public class InvoiceService : IInvoiceService
    {
        private const string Path = "invoices";
        private readonly RestClient _restClient;

        public InvoiceService(string clientSecret, string accessToken)
        {
            _restClient = new RestClient(new ApiHttpSettings(), clientSecret, accessToken);
        }

        public InvoiceService(ApiHttpSettings apiHttpSettings, string clientSecret, string accessToken)
        {
            _restClient = new RestClient(apiHttpSettings, clientSecret, accessToken);
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            var list = new List<Invoice>();
            var responseModel = await _restClient.GetAsync<FortnoxInvoiceResponseModel>(Path);

            list.AddRange(responseModel.Invoices);

            if (!responseModel.MetaInformation.Continue())
                return responseModel.Invoices;

            if (!int.TryParse(responseModel.MetaInformation.CurrentPage, out var currentPageNumber))
                throw new ArgumentException($"Could not parse '{responseModel.MetaInformation?.CurrentPage}' to int32");

            var nextPageResponseModel = await _restClient.GetAsync<FortnoxInvoiceResponseModel>(Path, page: currentPageNumber++);
            list.AddRange(nextPageResponseModel.Invoices);
            while (responseModel.MetaInformation.Continue())
            {
                currentPageNumber += 1;
                nextPageResponseModel = await _restClient.GetAsync<FortnoxInvoiceResponseModel>(Path, page: currentPageNumber);
                list.AddRange(nextPageResponseModel.Invoices);
            }
            return list;
        }
    }
}