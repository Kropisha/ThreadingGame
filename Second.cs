using System.Collections.Generic;
using System.Threading;

namespace ThreadingGame
{
    class Second
    {
        public static void DoWork()
        {
            Dictionary<int, string> value = null;
            Thread newThread = new Thread(() => { value = BL.ExecMethod(); });
            newThread.Start();
            newThread.Join();
            UI.ToDoc(value, Mode.Second);
        }
    }
}
