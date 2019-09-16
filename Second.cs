using System.Collections.Generic;
using System.Threading;

namespace ThreadingGame
{
    class Second
    {
        public static void DoWork()
        {
            Dictionary<int, double> value = null;
            Thread newThread = new Thread(() => { value = BL.ExecMethod(); });
            newThread.Start();
            newThread.Join();
            BL.ToExcel(value, Mode.Second);
        }
    }
}
