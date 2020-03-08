using Nordq.Fortnox.SDK.Models;

namespace Nordq.Fortnox.SDK.Extensions
{
    public static class FortnoxPaginationExtension
    {
        public static bool Continue(this FortnoxResponseMetaData metaData)
        {
            int.TryParse(metaData.CurrentPage, out var currentPageNumber);
            int.TryParse(metaData.TotalPages, out var totalPagesNumber);
            return currentPageNumber < totalPagesNumber;
        }
    }
}
