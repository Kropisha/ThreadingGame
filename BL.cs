using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ThreadingGame
{
    public class BL
    {
        private const string pattern = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

        public static char GetRandomChar()
        {
            Random rand = new Random();
            int num = rand.Next(0, pattern.Length);
            return pattern[num];
        }

        public static string GetRandomString()
        {
            string result = string.Empty;
            for (int i = 0; i < 1000; i++)
            {
                result += GetRandomChar();
            }

            return result;
        }

        public string[] GetStringSet(int count)
        {
            string[] current = new string[count];

            for (int i = 0; i < count; i++)
            {
                current[i] = GetRandomString();
            }

            return current;
        }

        public void ExecMethod()
        {
            int quality =int.Parse(Console.ReadLine());
            string[] result = GetStringSet(quality);
            Dictionary<char, int> general = new Dictionary<char, int>();

            Stopwatch s1 = new Stopwatch();
            s1.Start();
            foreach (string str in result)
            {
                Dictionary<char, int> temp = new Dictionary<char, int>();
                temp = Extensions.CharacterCount(str);
                if (result[0] == str)
                {
                    general = temp;
                }
                else
                {
                    foreach (var ch in temp.Keys)
                    {
                        general[ch] += temp[ch];
                    }
                }
            }
            s1.Stop();

            foreach (var character in general)
            {
                Console.WriteLine("{0} - {1}", character.Key, character.Value);
            }

            Console.WriteLine("Time elapsed: {0}", s1.Elapsed.TotalSeconds);
        }
    }

    static class Extensions
    {
        public static Dictionary<char, int> CharacterCount(this string text)
        {
            return text.GroupBy(c => c)
                .OrderBy(c => c.Key)
                .ToDictionary(grp => grp.Key, grp => grp.Count());
        }
    }
}
