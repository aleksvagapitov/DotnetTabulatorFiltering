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

        public async Task<TabulatorViewModel> GetFilteredData (int page, int size, List<Dictionary<string, string>> filters, List<Dictionary<string, string>> sorters)
        {
            var contactFilters = new Filters<Contact> ();
            var contactSorts = new Sorts<Contact> ();

            // Building Filters
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    var field = filter["field"];
                    var value = filter["value"];
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

            // Building Sortring
            if (sorters != null)
            {
                foreach (var sorter in sorters)
                {
                    var field = sorter["field"];
                    var dir = sorter["dir"] == "asc" ? true : false;
                    switch (field)
                    {
                        case "age":
                            contactSorts.Add (true, x => x.Age, dir);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
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