using ConsoleApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json.Serialization;
using System.Numerics;
using System.Text.Json;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters;
using System.Linq;
using System.Collections;
using NUnit.Framework;

namespace ConsoleApp1
{
    internal class ProgramBai7 : System.Text.Json.Serialization.JsonConverter<BigInteger>, IBaiTap
    {
        Bai7Model bai7 = new Bai7Model();
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "consoleapp1", "bai7.json");
        public ProgramBai7() { }

        public void History(string searchKey = "")
        {
            var historyContent = File.ReadAllText(_filePath);
            if (!string.IsNullOrWhiteSpace(historyContent))
            {
                var obj = JsonConvert.DeserializeObject<List<Bai7Model>>(historyContent);
                var historyStr = new StringBuilder();
                for (var i = 0; i < obj.Count; i++)
                {
                    historyStr.Append($"Lich su lan {i + 1}{Environment.NewLine}");
                    historyStr.Append($"So duoc nhap vao {obj[i].n} {Environment.NewLine}");
                    historyStr.Append($"So duoc nhap vao {obj[i].giaithua} {Environment.NewLine}");
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
            Console.Write("Nhap vao so can tinh giai thua: ");
            BigInteger a;
            while (!BigInteger.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Nhap sai, yêu cau nhap lai:");
            }
            bai7.n = a;

        }

        public void Output()
        {
            Console.WriteLine($"{bai7.n}! = {bai7.giaithua}");
        }

        public void Process()
        {
            bai7.giaithua = 1;
            for (BigInteger i = 1; i <= bai7.n; i++)
            {
                bai7.giaithua *= i;
            }
        }
        public void Save()
        {
            var dir = new FileInfo(_filePath).Directory;
            if (!Directory.Exists(dir.FullName))
            {
                Directory.CreateDirectory(dir.FullName);
            }
            List<Bai7Model> obj = new List<Bai7Model>();
            if (File.Exists(_filePath))
            {
                var fileContent = File.ReadAllText(_filePath);
                // cập nhật

                var temp = JsonConvert.DeserializeObject<List<Bai7Model>>(fileContent);
                if (temp != null)
                {
                    obj = temp;
                }
            }

            obj.Add(bai7);
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
            Console.WriteLine("-------------------Chuong trinh tinh giai thua cua mot so-------------------");
        }
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Number)
                throw new Newtonsoft.Json.JsonException(string.Format("Found token {0} but expected token {1}", reader.TokenType, JsonTokenType.Number));
            using var doc = JsonDocument.ParseValue(ref reader);
            return BigInteger.Parse(doc.RootElement.GetRawText(), NumberFormatInfo.InvariantInfo);
        }

        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            var s = value.ToString(NumberFormatInfo.InvariantInfo);
            using var doc = JsonDocument.Parse(s);
            doc.WriteTo(writer);
        }
    }
}
