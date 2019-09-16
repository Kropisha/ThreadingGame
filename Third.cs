using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadingGame
{
    public class Third
    {
        public static void DoWork()
        {
            Dictionary<int, double> value = null;
            Parallel.Invoke(() => {value = BL.ExecMethod(); });
            BL.ToExcel(value, Mode.Third);
        }
    }
}
