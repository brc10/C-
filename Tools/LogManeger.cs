using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Tools
{
    public static class LogManeger
    {

        private static string LogDirPath = "Log";
        static int day = DateTime.Now.Day;
        static int month = DateTime.Now.Month;
        static int year = DateTime.Now.Year;
        public static string DirPathFolder()
        { return LogDirPath + "/" + month.ToString(); }
        public static string DirPathFile()
        { return DirPathFolder() + "/" + day.ToString() + ".txt"; }

        //כתיבה ללוג
        private static void CreateLogFile()
        {
            day = DateTime.Now.Day;
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            DirectoryInfo logDir = Directory.CreateDirectory(LogDirPath);

            //בדיקה האם קיימת תיקיה לשנה הנוכחית
            if (!Directory.Exists($@"{logDir.FullName}\{year}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory(year.ToString());
            }

            //בדיקה האם קיימת תיקיה לחודש הנוכחי
            if (!Directory.Exists($@"{logDir.FullName}\{year}\{month}"))
            {
                //יוצרים תת תיקיה עבור השנה
                logDir.CreateSubdirectory($@"{year}\{month}");
            }

            if (!File.Exists($@"{logDir.FullName}\{year}\{month}\{day}.txt"))
            {
                File.Create($@"{logDir.FullName}\{year}\{month}\{day}.txt").Close();
            }
        }
        /// פונקצית עזר     

        public static void WriteToLog(string message)
        {
            CreateLogFile();
            DirectoryInfo logDir = Directory.CreateDirectory(LogDirPath);

            string filePath = $@"{logDir.FullName}\{year}\{month}\{day}.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }

        // בתוך LogManeger - שינוי החתימה כדי לקבל פרמטר נוסף
        public static void WriteStart(string className, string methodName, string message = null)
        {
            WriteToLog($"{DateTime.Now}\tStart {className}.{methodName}\t{message}");
        }

        public static void WriteEnd(string className, string methodName, string message = null)
        {
            WriteToLog($"{DateTime.Now}\tEnd {className}.{methodName}\t{message}");
        }
        public static void CleanLog()
        {
            if (!Directory.Exists(LogDirPath)) return; // הגנה מפני קריסה אם התיקייה לא קיימת
            string[] files = Directory.GetFiles(LogDirPath, "*", SearchOption.AllDirectories);
            // ... המשך הלוגיקה

            string[] rootPath = Directory.GetFiles(LogDirPath);
            if (!Directory.Exists(LogDirPath)) return;
            DateTime limitDate = DateTime.Now.AddMonths(-2);
            // עוברים על כל תיקיות השנים
            foreach (string yearDir in rootPath)
            {
                FileInfo fileInfo = new FileInfo(yearDir);

                // אם הקובץ נוצר לפני תאריך היעד - מוחקים אותו
                if (fileInfo.CreationTime < limitDate)
                {
                    try
                    {
                        fileInfo.Delete();
                    }
                    catch
                    {
                        //מתעלמים
                    }
                }
                // אם תיקיית השנה התרוקנה לגמרי, נמחק גם אותה
                if (Directory.GetDirectories(yearDir).Length == 0)
                {
                    Directory.Delete(yearDir);
                }

            }

        }
    }
}

