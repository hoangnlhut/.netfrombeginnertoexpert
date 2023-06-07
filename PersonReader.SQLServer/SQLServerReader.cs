using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PersonReader.Interface;

namespace PersonReader.SQLServer
{
    public class SQLServerReader : IPersonReader
    {
        DbContextOptions<PersonContext> options;
        public SQLServerReader()
        {
            var optionBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}People.db");
            options = optionBuilder.Options;
        }
        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PersonContext(options))
            {
                return context.People.ToList();
            }
        }

        public Person GetPerson(int id)
        {
            var people = GetPeople();
            var person = people.FirstOrDefault(p => p.Id == id);
            return person;

        }
    }
}