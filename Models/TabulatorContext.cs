using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotnetTabulatorFiltering.Models
{
    public class TabulatorContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public TabulatorContext (DbContextOptions<TabulatorContext> options) : base (options) { }

        public void EnsureSeedData ()
        {
            Contacts.Add (new Contact { Id = 1, FirstName = "John", LastName = "Doe", Age = 37, Gender = "Male", Email = "john@mail.com", ZipCode = 27526, About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. In est ante in nibh mauris cursus mattis. Arcu risus quis varius quam quisque id diam vel. Senectus et netus et malesuada fames ac turpis. Et malesuada fames ac turpis egestas maecenas pharetra convallis posuere. Nibh nisl condimentum id venenatis a condimentum vitae. Ac odio tempor orci dapibus ultrices in iaculis." });
            Contacts.Add (new Contact { Id = 2, FirstName = "Peter", LastName = "Jones", Age = 49, Gender = "Male", Email = "peter@example.com", ZipCode = 30043, About = "Varius quam quisque id diam vel quam elementum pulvinar etiam. Phasellus vestibulum lorem sed risus ultricies tristique nulla aliquet. Pulvinar pellentesque habitant morbi tristique senectus et netus et. Ut morbi tincidunt augue interdum. Erat velit scelerisque in dictum non consectetur a erat. At varius vel pharetra vel." });
            Contacts.Add (new Contact { Id = 3, FirstName = "Mary", LastName = "Smith", Age = 52, Gender = "Female", Email = "mary@mail.com", ZipCode = 12401, About = "Tincidunt arcu non sodales neque sodales ut etiam. Euismod nisi porta lorem mollis aliquam ut. Facilisis mauris sit amet massa vitae tortor condimentum." });
            Contacts.Add (new Contact { Id = 4, FirstName = "Ian", LastName = "Green", Age = 34, Gender = "Male", Email = "ian@example.com", ZipCode = 94603, About = "Nisl nunc mi ipsum faucibus vitae aliquet nec ullamcorper. Laoreet id donec ultrices tincidunt arcu non sodales neque sodales." });
            Contacts.Add (new Contact { Id = 5, FirstName = "Nancy", LastName = "Brownwood", Age = 22, Gender = "Female", Email = "nancy@address.com", ZipCode = 10512, About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut sem nulla pharetra diam sit amet nisl suscipit adipiscing. Nullam eget felis eget nunc lobortis mattis aliquam faucibus purus." });
            Contacts.Add (new Contact { Id = 6, FirstName = "Tommy", LastName = "High", Age = 29, Gender = "Male", Email = "tommy@example.com", ZipCode = 06033, About = "Cursus mattis molestie a iaculis at erat pellentesque adipiscing. Urna cursus eget nunc scelerisque viverra mauris in aliquam. Eu consequat ac felis donec et odio pellentesque diam volutpat." });
            Contacts.Add (new Contact { Id = 7, FirstName = "Gabriel", LastName = "Santos", Age = 37, Gender = "Female", Email = "gabriel@address.com", ZipCode = 28104, About = "Viverra vitae congue eu consequat ac felis donec. Magna etiam tempor orci eu lobortis elementum nibh tellus. Libero nunc consequat interdum varius sit amet mattis." });
            Contacts.Add (new Contact { Id = 8, FirstName = "Ryan", LastName = "James", Age = 43, Gender = "Male", Email = "ryan@mail.com", ZipCode = 07631, About = "Felis eget velit aliquet sagittis id consectetur purus ut faucibus. A arcu cursus vitae congue mauris rhoncus aenean vel. Elementum eu facilisis sed odio." });
            Contacts.Add (new Contact { Id = 9, FirstName = "Marc", LastName = "James", Age = 19, Gender = "Male", Email = "marc@example.com", ZipCode = 02038, About = "Lacus sed turpis tincidunt id aliquet risus. Odio euismod lacinia at quis. Proin fermentum leo vel orci porta non pulvinar neque." });
            Contacts.Add (new Contact { Id = 10, FirstName = "James", LastName = "Dallas", Age = 33, Gender = "Male", Email = "james@address.com", ZipCode = 53154, About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sed viverra ipsum nunc aliquet bibendum enim facilisis. Id semper risus in hendrerit gravida rutrum quisque." });
            Contacts.Add (new Contact { Id = 11, FirstName = "Ron", LastName = "Steer", Age = 44, Gender = "Male", Email = "ron@example.com", ZipCode = 55912, About = "Tellus id interdum velit laoreet id donec ultrices. Arcu cursus vitae congue mauris rhoncus. Donec enim diam vulputate ut." });
            Contacts.Add (new Contact { Id = 12, FirstName = "Liam", LastName = "Schwarz", Age = 21, Gender = "Male", Email = "liam@example.com", ZipCode = 48150, About = "Orci nulla pellentesque dignissim enim sit amet venenatis urna. Ultrices vitae auctor eu augue ut lectus. Pellentesque habitant morbi tristique senectus et netus et malesuada." });

            SaveChanges ();
        }
    }
}