using System;

namespace ThreadingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BL bl = new BL();
            bl.ExecMethod();
            Console.ReadKey();
        }
    }
}
