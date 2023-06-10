public class Program
{
    private static async Task Main(string[] args)
    {
        #region Chronous - Lập trình đồng bộ
        Console.WriteLine("Chronous - Lập trình đồng bộ");

        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        ThreadOne();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        ThreadTwo();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        watch.Stop();
        #endregion

        #region AsyncChronous - Lập trình bất đồng bộ OLD-WAY
        Console.WriteLine("AsyncChronous - Lập trình bất đồng bộ");
        var watch2 = new System.Diagnostics.Stopwatch();
        watch2.Start();

        //using thread for asynchronous
        Thread th_one = new Thread(ThreadOne);
        Thread th_two = new Thread(ThreadTwo);

        th_one.Start();
        Console.WriteLine($"Execution Time thread one start: {watch2.ElapsedMilliseconds} ms");
        th_two.Start();
        Console.WriteLine($"Execution Time thread two start: {watch2.ElapsedMilliseconds} ms");
        // Chặn luồng tiếp tục cho tới khi các tiến trình th_one và th_two hoàn thành
        th_one.Join();
        Console.WriteLine($"Execution Time thread one join: {watch2.ElapsedMilliseconds} ms");
        th_two.Join();
        Console.WriteLine($"Execution Time thread two join: {watch2.ElapsedMilliseconds} ms");

        watch2.Stop();
        Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");

        #endregion

        #region AsyncChronous - Lập trình bất đồng bộ NEW
        Console.WriteLine("AsyncChronous - Lập trình bất đồng bộ NEW");
        var watch3 = new System.Diagnostics.Stopwatch();
        watch3.Start();

        //var task3Async = TaskThree();
        //var task4Async = TaskFour();
        //Task.WaitAll(task3Async, task4Async);

        //await TaskFive();
        //Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");
        //await TaskSix("haha");
        //Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");


        //var task3Async =  await TaskFive();
        //var task4Async = await TaskSix("haha");
        //Console.WriteLine($"Task 5: {task3Async}");
        //Console.WriteLine($"Task 6: {task4Async}");

        var task3Async =  TaskFive();
        var task4Async =  TaskSix("haha");
        Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");
        var results = await Task.WhenAll(task3Async, task4Async);
        Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");

        Console.WriteLine($"Task 5: {results[0]}");
        Console.WriteLine($"Task 6: {results[1]}");

        watch3.Stop();
        Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");

        #endregion
    }

    private static async Task<string> TaskFive()
    {
        await Task.Delay(4000);
        return "TaskFive";
    }

    private static async Task<string> TaskSix(string name)
    {
        await Task.Delay(7000);
        return "TaskSix " + name;
    }

    private static async Task TaskFour()
    {
        Thread.Sleep(3000);
        Console.WriteLine("TaskFour");
    }

    private static async Task TaskThree()
    {
        Thread.Sleep(4000);
        Console.WriteLine("TaskThree");
    }

    private static void ThreadOne()
    {
        Thread.Sleep(5000);
        Console.WriteLine("ThreadOne");
    }

    private static void ThreadTwo()
    {
        Thread.Sleep(2000);
        Console.WriteLine("ThreadTwo");
    }
}