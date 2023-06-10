namespace WorkingWithC_9Records
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Hello, Worldaaaa!"); 

            var courRecord = new CourseRecord(
                "lap trinh c#",
                "Hoang Nguyen Le"
                );

            var newCourRe = courRecord with { Name = "Nghe Thuat Ve Tranh", Author = "Trang" };
            Console.WriteLine($"Name: {newCourRe.Name}");
            Console.WriteLine($"Author: {newCourRe.Author}");

            var (name, author) = courRecord;
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Author: {author}");
        }
    }

    //value can not be change after constructed
    public record CourseRecord(string Name, string Author);
}