using System;
using System.Collections.Generic;
using System.IO;

namespace ThreadingGame
{
    public class UI
    {
        public static void Print(Dictionary<char, int> general,string tsOut)
        {
            foreach (var character in general)
            {
                Console.WriteLine("{0} - {1}", character.Key, character.Value);
            }

            Console.WriteLine("Time elapsed: {0}", tsOut);
        }

        public static void ToDoc(Dictionary<int, string> data, Mode mode)
        {

            switch (mode)
            {
                case Mode.First:
                    using (StreamWriter sw = new StreamWriter(Path.GetFullPath("statistics.txt"), false,
                        System.Text.Encoding.Default))
                    {
                        foreach (var value in data.Values)
                        {
                            sw.Write(value + ",");
                        }

                        sw.WriteLine();
                    }

                    break;
                case Mode.Second:
                    using (StreamWriter sw = new StreamWriter(Path.GetFullPath("statistics.txt"), true,
                        System.Text.Encoding.Default))
                    {
                        foreach (var value in data.Values)
                        {
                            sw.Write(value + ",");
                        }

                        sw.WriteLine();
                    }

                    break;
                case Mode.Third:
                    using (StreamWriter sw = new StreamWriter(Path.GetFullPath("statistics.txt"), true,
                        System.Text.Encoding.Default))
                    {
                        foreach (var value in data.Values)
                        {
                            sw.Write(value + ",");
                        }
                    }

                    break;
            }
        }

        public static void BeautyRead()
        {
            string[] arStr = File.ReadAllLines(Path.GetFullPath("statistics.txt"));
            List<string[]> list = new List<string[]>();
            foreach (var str in arStr)
            {
                string[] temp = str.Split(',');
                list.Add(temp);
            }
            Console.WriteLine("{0,10}   |{1,10}   |{2,10}   |{3,10}", "Value", "First", "Second", "Third");
            string[] first = list[0];
            string[] second = list[1];
            string[] third = list[2];
            for (int i = 0; i < BL.set.Length; i++)
            {
                Console.WriteLine("{0,10}   |{1,10}   |{2,10}   |{3,10}", BL.set[i], first[i], second[i], third[i]);
            }
        }
    }
}
