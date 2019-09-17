using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ThreadingGame
{
    public class BL
    {
        private const string pattern = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
        public static readonly int[] set = new[] { 200, 2000, 20000, 200000, 500000 }; //   20, 200, 500, 2000, 5000
        private static int stringLength = 1000;

        private static char GetRandomChar()
        {
            Random rand = new Random();
            int num = rand.Next(0, pattern.Length);
            return pattern[num];
        }

        private static string GetRandomString(int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += GetRandomChar();
            }

            return result;
        }

        private static string[] GetStringSet(int count)
        {
            string[] current = new string[count];

            for (int i = 0; i < count; i++)
            {
                current[i] = GetRandomString(stringLength);
            }

            return current;
        }

        public static Dictionary<int, string> ExecMethod()
        {
            double value = 0;
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach (var val in set)
            {
                string[] resultStr = GetStringSet(val);
                Dictionary<char, int> general = new Dictionary<char, int>();

                Stopwatch s1 = new Stopwatch();
                s1.Start();
                foreach (string str in resultStr)
                {
                    Dictionary<char, int> temp = new Dictionary<char, int>();
                    temp = CharacterCount(str);
                    if (resultStr[0] == str)
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

                int minutes = (int)s1.Elapsed.TotalMinutes;
                double fsec = 60 * (s1.Elapsed.TotalMinutes - minutes);
                int sec = (int)fsec;
                double ms = 1000 * (fsec - sec);
                string tsOut = String.Format("{0}:{1:D2}.{2:F0}", minutes, sec, ms);

                result.Add(val, tsOut);
                UI.Print(general, tsOut);
            }

            return result;
        }

        private static Dictionary<char, int> CharacterCount(string text)
        {
            return text.GroupBy(c => c)
                .OrderBy(c => c.Key)
                .ToDictionary(grp => grp.Key, grp => grp.Count());
        }
        //public static void ToExcel(Dictionary<int, double> data, Mode mode)
        //{
        //    Excel.Application excel_app = new Excel.ApplicationClass();
        //    //excel_app.Visible = false;
        //    Excel.Workbook workbook = excel_app.Workbooks.Open(
        //        Path.GetFullPath("statistics.xlsx"), 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
        //        true, false, 0, true, false, false);

        //    // Посмотрим, существует ли рабочий лист.
        //    string sheet_name = DateTime.Now.ToString("MM-dd-yy");

        //    Excel.Worksheet sheet = (Excel.Worksheet)excel_app.Worksheets.get_Item(1);//FindSheet(workbook, sheet_name);
        //    if (sheet == null)
        //    {
        //        // Добавить лист в конце.
        //        sheet = (Excel.Worksheet)workbook.Sheets.Add(
        //            Type.Missing, workbook.Sheets[workbook.Sheets.Count],
        //            1, Excel.XlSheetType.xlWorksheet);
        //        sheet.Name = DateTime.Now.ToString("MM-dd-yy");
        //    }
        //    Range usedRange = sheet.UsedRange;
        //    sheet.Name = sheet_name;
        //    sheet.get_Range("A1").set_Value("value"); 
        //    // Добавить некоторые данные в отдельные ячейки.
        //  //  sheet.Cells[1, 1] = "Value";
        //    sheet.Cells[1, 2] = "First";
        //    excel_app.Range["A5"].Value2 = "Second";
        //    Excel.Range target = excel_app.Range["A7"];
        //    target.set_Value(Type.Missing, "A7");
        //    target.Value2 = "Name";
        //    sheet.Cells[1, 4] = "Third";

        //    // Делаем этот диапазон ячеек жирным и красным.
        //    //Excel.Range header_range = (Excel.Range)sheet.get_Range("A1", "D1");
        //    //header_range.Font.Bold = true;
        //    //header_range.Font.Color =
        //    //    ColorTranslator.ToOle(
        //    //        Color.Black);
        //    //header_range.Interior.Color =
        //    //    ColorTranslator.ToOle(
        //    //        Color.Pink);

        //    //Excel.Range value_range = sheet.get_Range("A2", "A6");
        //    //value_range.Value2 = set;
        //    //switch (mode)
        //    //{
        //    //    case Mode.First:
        //    //        Excel.Range value_range2 = sheet.get_Range("B2", "B6");
        //    ////        value_range.Value2 = data.Values;
        //    //        break;
        //    //    case Mode.Second:
        //    //        Excel.Range value_range3 = sheet.get_Range("C2", "C6");
        //    //  //      value_range.Value2 = data.Values;
        //    //        break;
        //    //    case Mode.Third:
        //    //        Excel.Range value_range4 = sheet.get_Range("D2", "D6");
        //    // //       value_range.Value2 = data.Values;
        //    //        break;
        //    //}
        //    //workbook.SaveAs(Path.GetFullPath("statistics.xlsx"), XlFileFormat.xlWorkbookNormal,
        //    //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //    //    XlSaveAsAccessMode.xlExclusive,
        //    //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //    excel_app.DisplayAlerts = false;
        //    workbook.SaveAs(Path.GetFullPath("statistics.xlsx"), Excel.XlFileFormat.xlOpenXMLWorkbook,
        //        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange,
        //        Excel.XlSaveConflictResolution.xlLocalSessionChanges, Missing.Value, Missing.Value,
        //        Missing.Value, Missing.Value);
        //    workbook.Close();
        //    //workbook.Close(true, Type.Missing, Type.Missing);
        //    excel_app.Quit();
        //    Marshal.ReleaseComObject(sheet);
        //    Marshal.ReleaseComObject(workbook);
        //    Marshal.ReleaseComObject(excel_app);
        //}

        //private static Excel.Worksheet FindSheet(Excel.Workbook workbook, string sheet_name)
        //{
        //    if (workbook.Sheets.Count != 0)
        //    {
        //        foreach (Excel.Worksheet sheet in workbook.Sheets)
        //        {
        //            if (sheet.Name == sheet_name) return sheet;
        //        }
        //    }

        //    return null;
        //}
    }
}
