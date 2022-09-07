using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Numerics;

namespace ConsoleApp1.Program
{
    internal class ProgramBai8 : IBaiTap
    {
        Bai8Model bai8 = new Bai8Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai8.json");
        public ProgramBai8() { }

        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai8Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"So nhap vao {obj[i].sothu1} {Environment.NewLine}");
                    historyStr.Append($"So nhap vao {obj[i].sothu2} {Environment.NewLine}");
                    historyStr.Append($"Tong {obj[i].tong}{Environment.NewLine}");
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
            Console.Write("Nhap vao so a: ");
            BigInteger a;
            while (!BigInteger.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai8.sothu1 = a;
            bai8.n = a;
            Console.Write("Nhap vao so b: ");
            BigInteger b;
            while (!BigInteger.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai8.sothu2 = b;
        }

        public void Output()
        {
            Console.WriteLine($"Tong 2 so la: {bai8.tong}");

        }

        public void Process()
        {
            bai8.tong = bai8.sothu1 + bai8.sothu2;
        }

        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai8Model> obj = new List<Bai8Model>();
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật

                var temp = JsonConvert.DeserializeObject<List<Bai8Model>>(fileContent);
                if (temp != null)
                {
                    obj = temp;
                }
            }
            obj.Add(bai8);
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("Luu lich su thanh cong");
            bai8.tong = 0;
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
            Console.WriteLine("-------------------Chuong trinh tinh tong cac chu so -------------------");
        }
    }
}
