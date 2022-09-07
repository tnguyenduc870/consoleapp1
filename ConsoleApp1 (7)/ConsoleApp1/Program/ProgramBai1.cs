using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ConsoleApp1.Program
{
    internal class ProgramBai1 : IBaiTap
    {
        Bai1Model bai1 = new Bai1Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai1.json");
        public ProgramBai1() { }

        public void History(string searchKey = "")
        {
            int first, middle, last;
            bool found = false;
            var historyContent = File.ReadAllText(_filePath);

            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                
                var obj = JsonConvert.DeserializeObject<List<Bai1Model>>(historyContent);
                var historyStr = new StringBuilder();

                for (var i = 0; i < obj.Count; i++)
                {
                    first = 0;
                    last = obj.Count - 1;
                    var currentItem = obj[i];
                    while (first <= last)
                    {
                        if (!string.IsNullOrWhiteSpace(searchKey))
                        {
                            // có tìm kiếm
                            middle = (first + last) / 2;
                            if (currentItem.ChieuDai < middle && currentItem.ChieuDai.ToString() == searchKey)
                                first = middle + 1;
                            if (currentItem.ChieuDai.ToString() == searchKey || currentItem.ChieuRong.ToString() == searchKey || currentItem.ChuVi.ToString() == searchKey)
                            {
                                AddHistoryResult(historyStr, currentItem, i);
                            }
                        }
                        else
                        {
                            AddHistoryResult(historyStr, currentItem, i);
                        }
                    }
                }

                if (historyStr.Length == 0)
                {
                    Console.WriteLine($"Khong tim thay lich su co tu khoa \"{searchKey}\"");
                } else
                {
                    Console.WriteLine(historyStr.ToString());
                }
            }
            else
            {
                Console.WriteLine("Chua co lich su");
            }
        }

        private void AddHistoryResult(StringBuilder historyStr, Bai1Model currentItem, int i)
        {
            // chỉ cần in danh sách, không cần tìm kiếm
            historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
            historyStr.Append($"Chieu dai / Chieu rong: {currentItem.ChieuDai} / {currentItem.ChieuRong}{Environment.NewLine}");
            historyStr.Append($"Chu vi {currentItem.ChuVi}{Environment.NewLine}");
        }

        public void Input()
        {
            Console.Write("Nhap vao chieu dai a: ");
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai1.ChieuDai = a;

            Console.Write("Nhap vao chieu rong b: ");
            int b;
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai1.ChieuRong = b;
        }

        public void Output()
        {
            Console.WriteLine($"Chu vi hinh chu nhat la: {bai1.ChuVi}");
        }

        public void Process()
        {
            bai1.ChuVi = (bai1.ChieuDai + bai1.ChieuRong) * 2;
        }

        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai1Model> obj;
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật
                obj = JsonConvert.DeserializeObject<List<Bai1Model>>(fileContent);
            }
            else
            {
                obj = new List<Bai1Model>();
            }

            obj.Add(bai1);
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
                }
                else
                    break;
            } while (true);
        }

        public void Welcome()
        {
            Console.WriteLine("-------------------Chuong trinh tinh chu vi hinh chu nhat-------------------");
        }
    }
}
