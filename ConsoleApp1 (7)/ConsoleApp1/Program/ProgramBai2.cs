using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ConsoleApp1.Program
{
    internal class ProgramBai2 : IBaiTap
    {
        Bai2Model bai2 = new Bai2Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai2.json");
        public ProgramBai2() { }
        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai2Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"numberOfElements: {obj[i].numberOfElements}{Environment.NewLine}");
                    historyStr.Append($"number {obj[i].number}{Environment.NewLine}");
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
            Console.Write("Nhap vao so phan tu day Fibonacci ban muon in: ");
            decimal a;
            while (!decimal.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai2.numberOfElements = a;
        }

        public void Output()
        {
            Console.Write("Day Fibonacci: ");
            for (int i = 0; i < bai2.numberOfElements; i++)
            {
                Console.Write(bai2.number + "\t");
                //gọi hàm InFibonacci() với tham số truyền vào là number
                bai2.number++;
            }
        }

        public void Process()
        {
            if (bai2.num == 0) ;
            else if (bai2.num == 1) ;
            else
                Console.Write(bai2.num - 1 + (bai2.num - 2));
        }

        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai2Model> obj;
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật
                obj = JsonConvert.DeserializeObject<List<Bai2Model>>(fileContent);
            }
            else
            {
                obj = new List<Bai2Model>();
            }

            obj.Add(bai2);
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("\nLuu lich su thanh cong");
            bai2.number = 0;
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
            Console.WriteLine("-------------------Chuong trinh In day so Fibonacci-------------------");
        }
    }
}
