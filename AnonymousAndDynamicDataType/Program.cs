public class Program
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    private static void Main(string[] args)
    {
        #region Anonymous Data Type
        var dienthoai = new
        {
            Name = "Iphone8",
            Price = 300
        };

        Console.WriteLine($"Ten: {dienthoai.Name}");
        Console.WriteLine($"Gia: {dienthoai.Price}");

        List<Employee> list = new List<Employee>
        {
            new Employee{ Name = "Hoang", Age = 10},
            new Employee{ Name = "Trang", Age = 9},
            new Employee{ Name = "Pooh", Age = 5},
        };

        var filter = list.Where(x => x.Age >= 9).ToList();
        foreach (var item in filter)
        {
            Console.WriteLine($"{item.Name}");
        }
        #endregion

        #region Dynamic Data Type

        #endregion
    }
}