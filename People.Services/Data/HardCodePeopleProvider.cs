namespace People.Services.Data
{
    public class HardCodePeopleProvider : IPeopleProvider
    {
        public List<Person> GetPeople()
        {
            var p = new List<Person>()
            {
                new Person(1, "John", "Koenig", new DateTime(1975, 11, 17), 6, ""),
                new Person(2, "Dylan", "Hunt", new DateTime(1985, 12, 17), 7, ""),
                new Person(3, "Lela", "Turanga", new DateTime(1995, 3, 17), 8, ""),
                new Person(4, "John", "Crichton", new DateTime(1925, 4, 17), 9, ""),
                new Person(5, "Dave", "Lister", new DateTime(1935, 5, 17), 1, ""),
                new Person(6, "Laura", "Roslin", new DateTime(1955, 6, 17), 2, ""),
                new Person(7, "John", "Sheridan", new DateTime(1945, 7, 17), 3, ""),
                new Person(8, "Dante", "Montana", new DateTime(1965, 8, 17), 4, ""),
                new Person(9, "Issac", "Gampu", new DateTime(1985, 9, 17), 5, ""),
            };
            return p;
        }
    }
}
