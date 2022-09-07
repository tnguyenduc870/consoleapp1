using ConsoleApp1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ConsoleApp1.Program
{
    internal class ProgramBai6 : IBaiTap
    {
        Bai6Model bai6 = new Bai6Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai6.json");
        public ProgramBai6() { }

        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai6Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"So da nhap {obj[i].temporaryNumber} {Environment.NewLine}");
                    historyStr.Append($"So duoc kiem tra co phai la so Armstrong hay khong {obj[i].temporaryNumber}{Environment.NewLine}");
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
            Console.Write("Nhap vao mot so: ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai6.number = a;
        }

        public void Output()
        {
            if (bai6.sum == bai6.temporaryNumber)
            {
                Console.WriteLine($"So {bai6.temporaryNumber} la so Armstrong");
            }
            else
            {
                Console.WriteLine($"So {bai6.temporaryNumber} khong phai la so Armstrong");
            }
        }
        public void Process()
        {
            bai6.digitCount = 0;
            bai6.digitArray = new int[1000];
            bai6.temporaryNumber = bai6.number;
            int i = 0;
            while (bai6.number > 0)
            {
                bai6.digitArray[i++] = bai6.number % 10;
                bai6.number = bai6.number / 10;
                bai6.digitCount++;
            }
            i = 0;
            //tính tổng lập phương các chữ số
            for (i = 0; i < bai6.digitCount; i++)
            {
                bai6.sum += Math.Pow(bai6.digitArray[i], bai6.digitCount);
            }
        }
        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai6Model> obj = new List<Bai6Model>();
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật

                var temp = JsonConvert.DeserializeObject<List<Bai6Model>>(fileContent);
                if (temp != null)
                {
                    obj = temp;
                }
            }

            obj.Add(bai6);
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("Luu lich su thanh cong");
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
            Console.WriteLine("-------------------Chuong trinh kiem tra so Armstrong-------------------");
        }
    }
}
