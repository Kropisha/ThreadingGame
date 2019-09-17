using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadingGame
{
    public class Third
    {
        public static void DoWork()
        {
            Dictionary<int, string> value = null;
            Parallel.Invoke(() => {value = BL.ExecMethod(); });
            UI.ToDoc(value, Mode.Third);
        }
    }
}
