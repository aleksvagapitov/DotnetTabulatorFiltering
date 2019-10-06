using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetTabulatorFiltering.Models
{
    public interface ITabulatorRepository
    {
        Task<TabulatorViewModel> GetFilteredData (int pageSize, int currentPage, Dictionary<string, Dictionary<string, string>> filters);
    }
}