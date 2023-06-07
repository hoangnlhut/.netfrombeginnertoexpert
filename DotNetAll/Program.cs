using Core.C_8Interface;
using System.Collections;
using System.Runtime.CompilerServices;

public class Program
{
    // khai báo kiểu delegate trả về void với tham số là string message
    public delegate void ShowLog(string  message); 

    //KHai báo thêm một hàm giống kiểu delegate
    public static void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static int Tong(int a, int b) => a + b;
    static int Hieu(int a, int b) => a - b;

    //Lập trình hướng sự kiện 
    //1: các lớp phát đi sự kiện: publisher
    //2. các lớp nhận sự kiện: subcriber
    // chú ý : pub - sub phải làm việc với delegate

    //delegate
    public delegate void SuKienNhapSo(int x);
    
    // publisher: lớp phát đi các sự kiện

    class DuLieuNhap : EventArgs
    {
        public int data { set; get; }
        public DuLieuNhap(int x) => data = x;
    }
    class UserInput
    {
        // kiểu event thì có thể += hoặc -= chứ không thể gán =
        //public event SuKienNhapSo suKienNhapSo;

        //kiểu khai báo mới dùng EvenHandler ~ 
        public event EventHandler suKienNhapSo;  // delegate void KIEU(object sender, EvenArgs arg)
        public void Input()
        {
            do
            {
                Console.WriteLine("Nhập vào số nguyên: ");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
                // phát đi sự kiện
                //dùng this cho đối tượng phát ra sự kiện
                suKienNhapSo?.Invoke(this, new DuLieuNhap(i));
            }
            while (true);
          
        }
    }

    class TinhCan
    {
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += Can;
        }
        // delegate void KIEU(object sender, EvenArgs arg)
        public void Can(object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap =  (DuLieuNhap)e;
            int i = duLieuNhap.data;
            Console.WriteLine($"Can bac hai cua {i} là {Math.Sqrt(i)}");
        }
    }

    class BinhPhuong
    {
        public void Sub(UserInput input)
        {
            input.suKienNhapSo += TinhBinhPhuong;
        }
        public void TinhBinhPhuong(object sender, EventArgs e)
        {
            DuLieuNhap duLieuNhap = (DuLieuNhap)e;
            int i = duLieuNhap.data;
            Console.WriteLine($"Bình Phương cua {i} là {i * i}");
        }
    }

    public interface ISavable
    {
        void Save();
    }

    public class Catalog : ISavable
    {
        public void Save()
        {
            Console.WriteLine("Save of Catalog");

        }
        void ISavable.Save()
        {
           Console.WriteLine("Save of ISavable");
        }
    }

    public class OddGenerator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int i = 1;
            yield return i;
            while(i < 20)
            {
                i += 2;
                yield return i;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    private static void Main(string[] args)
    {
        #region Event , Pub, Sub
        // publisher
        //UserInput userInput = new UserInput();

        //userInput.suKienNhapSo += (sender, e) =>
        //{
        //    DuLieuNhap duLieuNhap = (DuLieuNhap)e;
        //    int i = duLieuNhap.data;
        //    Console.WriteLine($"Su kien nhap so {i}");
        //};


        ////subcriber
        //TinhCan tinhCan = new TinhCan();
        //tinhCan.Sub(userInput);

        ////other subsriber
        //BinhPhuong binhPhuong = new BinhPhuong();
        //binhPhuong.Sub(userInput);

        //userInput.Input();
        #endregion

        #region Func  
        // Func thì như action thôi nhưng có kiểu trả về
        Func<int> f1;  // ~ delegate int KIEU();  --> trả về kiểu int và không có tham số.
        Func<string, double, string> f2;  // ~ delegate string KIEU(string , double);  --> trả về kiểu string và có 2 tham số.

        Func<int, int, int> f3; // ~ delegate 
        f3 = Tong;
        Console.WriteLine($"Tong 2 so: {f3.Invoke(10, 5)}");

        f3 = Hieu;
        Console.WriteLine($"Hieu 2 so: {f3.Invoke(10, 5)}");
        #endregion

        #region Action 
        //Action action;     // ~ delegate void KIEU(); không trả về gì và không có tham số -> kiểu ko có tham số
        //Action<string, int> action1; // delegate void KIEU(string s, int i) : không trả về gì và có tham số.
        //Action<string> action2;      // delegate void KIEU(string s): không trả về kiểu gì và có 1 tham sô chuỗi

        ////action1 = Warning;
        //action2 = Log;
        //action2?.Invoke("Log ne");
        //action2 += Warning;
        //action2?.Invoke("Warning ne");

        #endregion

        #region delegate
        //ShowLog showLog = null;
        //showLog = Log;

        ////Các cách để gọi hàm
        ////Cách 1
        //showLog("log thôi");

        ////Cách 2
        //showLog.Invoke("Log invoke");

        //showLog = Warning;
        //showLog("warning");

        //// tham chiếu một lúc nhiều phương thức dùng toán tử +=
        //showLog = null;

        //showLog += Log;
        //showLog += Warning;

        //showLog?.Invoke("Xin chao cac ban");
        #endregion

        #region Explicitly Interface
        //Catalog catalog = new Catalog();
        //catalog.Save();

        //ISavable savable =  catalog;
        //savable.Save();
        var oddGenerator = new OddGenerator();
        foreach (var item in oddGenerator)
        {
            Console.WriteLine(item);
        }

        #endregion

        //var square = new Square(5);
        //DisplayPolygon("Square", square);

        //var triangle = new Triangle(4);
        //DisplayPolygon("Triangle", triangle);

        //var octagon = new Octagon(4);
        //DisplayPolygon("Octagon", octagon);

        //Console.WriteLine("Hello, World!");
    }

    public static void DisplayPolygon(string polygonType, dynamic polygon)
    {
        var res = polygon;
        if (polygonType == "Square")
        {
           res = (Square)polygon; 

        }
        else if (polygonType == "Triangle")
        {
            res = (Triangle)polygon;
        }
        else
        {
            res = (Octagon)polygon;
        }
        //Console.WriteLine($"{typeof(Triangle)}");
        //Console.WriteLine($"{typeof(Square)}");
        //Console.WriteLine($"{typeof(Octagon)}");
        Console.WriteLine($"{polygonType} Number Of Sides: {res.NumberOfSides}");
        Console.WriteLine($"{polygonType} Side Length: {res.SideLength}");
        Console.WriteLine($"{polygonType} Perimeter: {res.GetPerimeter()}");
        Console.WriteLine($"{polygonType} Area: {res.GetArea()}");
    }
}