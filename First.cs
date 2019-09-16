using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadingGame
{
    public class First
    {
        public static void DoWork()
        {
            Task<Dictionary<int, double>> newTask = Task.Run(() => { return BL.ExecMethod(); });
            Task.WaitAll();
            BL.ToExcel(newTask.Result, Mode.First);
        }     
    }
}
