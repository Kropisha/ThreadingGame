using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadingGame
{
    public class First
    {
        public static void DoWork()
        {
            Task<Dictionary<int, string>> newTask = Task.Run(() => { return BL.ExecMethod(); });
            Task.WaitAll();
            UI.ToDoc(newTask.Result, Mode.First);
        }     
    }
}
