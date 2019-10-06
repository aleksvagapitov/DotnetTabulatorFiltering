using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkPaginateCore;

namespace DotnetTabulatorFiltering.Models
{
    public class TabulatorRepository : ITabulatorRepository
    {
        private readonly TabulatorContext _context;

        public TabulatorRepository (TabulatorContext context)
        {
            _context = context;
        }

        public async Task<TabulatorViewModel> GetFilteredData (int page, int size, Dictionary<string, Dictionary<string, string>> filters)
        {
            var contactFilters = new Filters<Contact> ();
            var contactSorts = new Sorts<Contact> ();

            if (filters != null)
            {
                foreach (var filter in filters.Keys)
                {
                    if (filter == "page" || filter == "size")
                        continue;
                    var field = filters[filter]["field"];
                    var value = filters[filter]["value"];
                    switch (field)
                    {
                        case "firstName":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.FirstName.Contains (value));
                            break;
                        case "lastName":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.LastName.Contains (value));
                            break;
                        case "age":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.Age.ToString ().Contains (value));
                            break;
                        case "gender":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.Gender.Contains (value));
                            break;
                        case "email":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.Email.Contains (value));
                            break;
                        case "zipCode":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.ZipCode.ToString ().Contains (value));
                            break;
                        case "about":
                            contactFilters.Add (!string.IsNullOrEmpty (value), x => x.About.Contains (value));
                            break;
                        default:
                            break;
                    }
                }
            }

            contactSorts.Add (true, x => x.Id);

            var contacts = await _context.Contacts.PaginateAsync (page, size, contactSorts, contactFilters);
            // mapper.Map<ViewModel>(contacts);

            var contractsViewModel = new TabulatorViewModel
            {
                Data = contacts.Results,
                Last_page = contacts.PageCount
            };

            return contractsViewModel;
        }
    }

}