using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ConsoleApp1.Program
{
    internal class ProgramBai5 : IBaiTap
    {
        Bai5Model bai5 = new Bai5Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai5.json");
        public ProgramBai5() { }

        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai5Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"So da nhap : {obj[i].n}{Environment.NewLine}");
                    historyStr.Append($"so dao nguoc {obj[i].reverse}{Environment.NewLine}");
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
            bai5.number = a;
            bai5.n = a;
        }

        public void Output()
        {
            Console.WriteLine($"So dao nguoc la : {bai5.reverse}");
        }

        public void Process()
        {
            while (bai5.number > 0)
            {
                bai5.reminder = bai5.number % 10;
                bai5.reverse = bai5.reverse * 10 + bai5.reminder;
                bai5.number = bai5.number / 10;
            }
        }

        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai5Model> obj;
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật
                obj = JsonConvert.DeserializeObject<List<Bai5Model>>(fileContent);
            }
            else
            {
                obj = new List<Bai5Model>();
            }

            obj.Add(bai5);
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("Luu lich su thanh cong");
            bai5.reverse = 0;
        }

        public bool Validate()
        {
            return true;
        }

        public async void Wait()
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
            Console.WriteLine("-------------------Chuong trinh đao nguoc mot so va mot chuoi-------------------");
        }
    }
}
