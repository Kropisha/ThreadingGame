using System;

namespace ThreadingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            First.DoWork();
            Second.DoWork();
            Third.DoWork();
            Console.WriteLine();
            UI.BeautyRead();
            Console.ReadKey();
        }
    }
}
