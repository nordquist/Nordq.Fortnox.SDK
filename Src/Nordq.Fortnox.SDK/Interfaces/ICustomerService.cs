using System.Collections.Generic;
using System.Threading.Tasks;
using Nordq.Fortnox.SDK.Models;

namespace Nordq.Fortnox.SDK.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers on account using internal pagination
        /// </summary>
        /// <returns><c>Customer</c> list</returns>
        Task<List<Customer>> GetAllCustomersAsync();
    }
}