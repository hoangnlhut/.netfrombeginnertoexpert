using PersonReader.Interface;

namespace PersonReader.CSV
{
    public class CSVReader : IPersonReader
    {
        public CSVFileLoader FileLoader { get; set; }
        public CSVReader() 
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "People.txt";
            FileLoader = new CSVFileLoader(filePath);
        }
        public IEnumerable<Person> GetPeople()
        {
            var fileData = FileLoader.LoadFile();
            var people = ParseData(fileData);
            return people;
        }

        public Person GetPerson(int id)
        {
            var people = GetPeople();
            return people.FirstOrDefault(p => p.Id == id);
        }

        private List<Person> ParseData(IReadOnlyCollection<string> csvData) 
        {
            var people =  new List<Person>();
            foreach (var line in csvData)
            {
                try
                {
                    var elems = line.Split(',');
                    var per = new Person()
                    {
                        Id = int.Parse(elems[0]),
                        GivenName = elems[1],
                        FamilyName = elems[2],
                        StartDate = DateTime.Parse(elems[3]),
                        Rating = int.Parse(elems[4]),
                        FormatString = elems[5]
                    };
                    people.Add(per);
                }
                catch (Exception)
                {
                    //skip the bad record, log it, and move to the next record
                    // log.write("Unable to parse record", per);
                }
            }

            return people;
        }
    }
}