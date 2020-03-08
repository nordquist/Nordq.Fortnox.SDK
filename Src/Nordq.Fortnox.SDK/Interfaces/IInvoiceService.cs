using System.Collections.Generic;
using System.Threading.Tasks;
using Nordq.Fortnox.SDK.Models;

namespace Nordq.Fortnox.SDK.Interfaces
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Gets all invoices on account using internal pagination
        /// </summary>
        /// <returns><c>Invoice</c> list</returns>
        Task<List<Invoice>> GetAllInvoicesAsync();
    }
}