using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ConsoleApp1.Program
{
    internal class ProgramBai4 : IBaiTap
    {
        Bai4Model bai4 = new Bai4Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai4.json");
        public ProgramBai4() { }

        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai4Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"So nhap vao {obj[i].sum}{Environment.NewLine}");
                    historyStr.Append($"So doi xung la: {obj[i].temp} {Environment.NewLine}");
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
            Console.Write("Nhap vao mot so can kiem tra : ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai4.number = a;
        }

        public void Output()
        {
            if (bai4.sum == bai4.temp)
            {
                Console.WriteLine($"So {bai4.temp} la so doi xung.");
            }
            else
            {
                Console.WriteLine($"So {bai4.temp} khong phai so doi xung");
            }
        }
        public void Process()
        {
            bai4.sum = 0;
            bai4.temp = bai4.number;
            while (bai4.number > 0)
            {
                //Chia lấy dư number cho 10 
                bai4.remineder = bai4.number % 10;
                //nhân tổng với 10 rồi cộng thêm phần dư
                bai4.sum = bai4.sum * 10 + bai4.remineder;
                //chia lấy nguyên cho 10
                bai4.number = bai4.number / 10;
            }
        }

        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai4Model> obj = new List<Bai4Model>();
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật

                var temp = JsonConvert.DeserializeObject<List<Bai4Model>>(fileContent);
                if (temp != null)
                {
                    obj = temp;
                }
            }
            obj.Add(bai4);
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
            Console.WriteLine("-------------------Chuong trinh Kiem tra so đoi xung-------------------");
        }
    }
}
