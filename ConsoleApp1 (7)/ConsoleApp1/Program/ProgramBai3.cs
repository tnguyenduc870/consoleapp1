using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ConsoleApp1.Program
{
    internal class ProgramBai3 : IBaiTap
    {
        Bai3Model bai3 = new Bai3Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai3.json");
        public ProgramBai3() { }

        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai3Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"So Number nhap vao {obj[i].number}{Environment.NewLine}");
                    historyStr.Append($"So IsPrime co phai so nguyen to hay khong: {obj[i].IsPrime} {Environment.NewLine}");
                }
                Console.WriteLine(historyStr.ToString());
            }
            else
            {
                Console.WriteLine("Chua co lich su");
            }
        }

        public void Input()
        {
            Console.Write("Nhap vao mot so nguyen bat ki: ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai3.number = a;

        }

        public void Output()
        {
            if (bai3.IsPrime)
            {
                Console.Write($"{bai3.number} la so nguyen to.");
            }
            else
            {
                Console.Write($"{bai3.number} khong phai so nguyen to.");
            }

        }

        public void Process()
        {
            for (int i = 2; i < bai3.number / 2; i++)
            {
                if (bai3.number % i == 0)
                {
                    bai3.IsPrime = false;
                    break;
                }
            }
        }

        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai3Model> obj;
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật
                obj = JsonConvert.DeserializeObject<List<Bai3Model>>(fileContent);
            }
            else
            {
                obj = new List<Bai3Model>();
            }

            obj.Add(bai3);
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("\nLuu lich su thanh cong");

        }

        public bool Validate()
        {
            return true;
        }

        public void Wait()
        {
            string key = "";
            do
            {
                Console.Write("Ban co muon tiep tuc? (Y/N): ");
                key = Console.ReadLine();
                if (key.Equals("Y") | key.Equals("y"))
                {
                    Input();
                    Process();
                    Output();
                    Save();
                }
                else
                    break;
            } while (true);
        }

        public void Welcome()
        {
            Console.WriteLine("-------------------Chuong trinh kiểm tra số nguyên tố-------------------");
        }
    }
}
