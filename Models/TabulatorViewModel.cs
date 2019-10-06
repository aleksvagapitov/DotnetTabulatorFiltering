using System;
using System.Collections.Generic;

namespace DotnetTabulatorFiltering.Models
{
    public class TabulatorViewModel
    {
        public IEnumerable<dynamic> Data { get; set; }
        public int Last_page { get; set; }
    }
}