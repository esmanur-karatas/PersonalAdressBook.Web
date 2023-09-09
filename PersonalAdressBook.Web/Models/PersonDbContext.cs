using Microsoft.EntityFrameworkCore;

namespace PersonalAdressBook.Web.Models
{
    public class PersonDbContext: DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; } 
    }
}
