using System.ComponentModel.DataAnnotations;

namespace DotnetTabulatorFiltering.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int ZipCode { get; set; }
        public string About { get; set; }
    }
}