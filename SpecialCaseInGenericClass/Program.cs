using System.ComponentModel;
using System.Data.SqlTypes;
using System.Net.WebSockets;

namespace SpecialCaseInGenericClass
{
    public  class Program
    {
        static void Main(string[] args)
        {
            var result = Add(2, 3);
            Console.WriteLine($"Add(2, 3) : {result}");

            var result2 = Add(2.2, 3.2);
            Console.WriteLine($"Add(2.2, 3.2) : {result2}");

            var results = Add("hoang ", "trang");
            Console.WriteLine($"Add(\"hoang \", \"trang\") : {results}");

            #region comment
            //_ = new Container<string>();
            //_ = new Container<string>();
            //_ = new Container<int>();



            //Console.WriteLine($"Container<string>: {Container<string>.ContainerCount}");
            //Console.WriteLine($"Container<string>: {Container<int>.ContainerCount}");
            //Console.WriteLine($"Container<string>: {Container<bool>.ContainerCount}");
            //Console.WriteLine($"Container Base: {ContainerBase.ContainerCountBase}");
            //var printString = new Container<string>();
            //printString.PrintItem("Toi la hoang");
            #endregion
        }

        public static T Add<T>(T v1, T v2) where T : notnull 
        {
            dynamic x, y;  // không check in compiler-time chỉ check lỗi khi run time
            x = v1;
            y = v2;
            return x + y;
        }
    }

    public class ContainerBase
    {
        public ContainerBase()
        {
            ContainerCountBase++;
        }

        //will count all container , it don' care whatever type of input value
        public static int ContainerCountBase { get; set; }
    }

    public class Container<T> : ContainerBase
    {
        public Container() {
            ContainerCount++;
        }

        //static member is created for every generic type that you define
        public static int ContainerCount { get; set; }

        //Generic method in generic class
        public void PrintItem<TItem>(TItem item)
        {
            Console.WriteLine($"{item}");
        }
    }
}