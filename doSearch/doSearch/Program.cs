using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace doSearch
{
    class Program
    {
        static void SearchFiles(string path)
        {
            string line;
            string result = "";
            var regex = new Regex(@"[а-яА-ЯёЁ]+");
            try
            {
                StreamReader sr = new StreamReader($"{path}", Encoding.UTF8);
                line = sr.ReadLine();
                while (line != null)
                {
                    foreach (var world in regex.Matches(line))
                    {
                        result += world + " ";
                    }
                    line = sr.ReadLine();
                }
                if (result != "")
                    Console.WriteLine($"{path} ## {result}");
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        static void Main(string[] args)
        {        
            if (args.Length != 0)
            {
                string path = args[0];
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (dirInfo.Exists)
                {
                    string[] filePaths = Directory.GetFiles(@$"{path}", "*.txt", SearchOption.AllDirectories);
                    if (filePaths.Length != 0)
                    {
                        foreach (string s in filePaths)
                        {
                            SearchFiles(s);
                        }
                    }
                    else
                        Console.WriteLine("Файлов не найдено!");
                }
                else
                    Console.WriteLine("Неверно указан путь!");
            }
        }
    }
}
