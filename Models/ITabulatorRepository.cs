using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetTabulatorFiltering.Models
{
    public interface ITabulatorRepository
    {
        Task<TabulatorViewModel> GetFilteredData (int pageSize, int currentPage, List<Dictionary<string, string>> filters, List<Dictionary<string, string>> sorters);
    }
}