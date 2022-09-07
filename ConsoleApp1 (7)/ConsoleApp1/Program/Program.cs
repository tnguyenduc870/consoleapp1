using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Numerics;

namespace ConsoleApp1.Program
{
    class Program
    {
        static void bai1()
        {
            var bai1 = new ProgramBai1();
            bai1.Welcome();
            bai1.Input();
            if (!bai1.Validate())
            {
                bai1.Input();
            }
            bai1.Process();
            bai1.Output();
            bai1.Save();
            bai1.Wait();
        }
        static void bai2()
        {
            var bai2 = new ProgramBai2();
            bai2.Welcome();
            bai2.Input();
            if (!bai2.Validate())
            {
                bai2.Input();
            }
            bai2.Process();
            bai2.Output();
            bai2.Save();
            bai2.Wait();
        }
        static void bai3()
        {
            var bai3 = new ProgramBai3();
            bai3.Welcome();
            bai3.Input();
            if (!bai3.Validate())
            {
                bai3.Input();
            }
            bai3.Process();
            bai3.Output();
            bai3.Save();
            bai3.Wait();
        }
        static void bai4()
        {
            var bai4 = new ProgramBai4();
            bai4.Welcome();
            bai4.Input();
            if (!bai4.Validate())
            {
                bai4.Input();
            }
            bai4.Process();
            bai4.Output();
            bai4.Save();
            bai4.Wait();
        }
        static void bai5()
        {
            var bai5 = new ProgramBai5();
            bai5.Welcome();
            bai5.Input();
            if (!bai5.Validate())
            {
                bai5.Input();
            }
            bai5.Process();
            bai5.Output();
            bai5.Save();
            bai5.Wait();
        }
        static void bai6()
        {
            var bai6 = new ProgramBai6();
            bai6.Welcome();
            bai6.Input();
            if (!bai6.Validate())
            {
                bai6.Input();
            }
            bai6.Process();
            bai6.Output();
            bai6.Save();
            bai6.Wait();
        }
        static void bai7()
        {
            var bai7 = new ProgramBai7();
            bai7.Welcome();
            bai7.Input();
            if (!bai7.Validate())
            {
                bai7.Input();
            }
            bai7.Process();
            bai7.Output();
            bai7.Save();
            bai7.Wait();

        }
        static void bai8()
        {
            var bai8 = new ProgramBai8();
            bai8.Welcome();
            bai8.Input();
            if (!bai8.Validate())
            {
                bai8.Input();
            }
            bai8.Process();
            bai8.Output();
            bai8.Save();
            bai8.Wait();
        }
        static void bai0()
        {

        }
        static void bai9()
        {
            try
            {
                /*Console.WriteLine("Thuật toán tìm kiếm nhị phân (Binary Search)");
                int  first, middle, last;
                bool found = false;
                //Thuật toán
                first = 0;
                last = n - 1;
                while (first <= last)
                {
                    middle = (first + last) / 2;
                    //Console.WriteLine("Vị trí giữa: {0}",middle);

                    if (a[middle] < key)
                        first = middle + 1;
                    else if (a[middle] == key)
                    {
                        Console.WriteLine("Tìm giá trị {0} ở vị trí {1} trong mảng", key, (middle + 1));
                        found = true;
                        break;
                    }
                    else
                        last = middle - 1;
                    //Console.WriteLine("First: {0}, Last: {1}", middle, last);
                }
                if (found == false)
                    Console.WriteLine("Không tìm thấy giá trị tìm kiếm");*/
                Console.Write("Chon bai can xem lich su: ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ban co muon tim kiem trong lich su? (y/n):");
                var typedKey = Console.ReadKey();
                var isSearch = typedKey.Key.ToString().ToLower() == "y";
                var searchKey = string.Empty;
                if (isSearch)
                {
                    Console.Write(Environment.NewLine);
                    Console.Write("Nhap gia tri can tim kiem: ");
                    searchKey = Console.ReadLine();
                }
                Console.Write(Environment.NewLine);
                switch (key)
                {
                    case 1:
                        var bai1 = new ProgramBai1();
                        bai1.History(searchKey);
                        break;
                    case 2:
                        var bai2 = new ProgramBai2();
                        bai2.History();
                        break;
                    case 3:
                        var bai3 = new ProgramBai3();
                        bai3.History();
                        break;
                    case 4:
                        var bai4 = new ProgramBai4();
                        bai4.History();
                        break;
                    case 5:
                        var bai5 = new ProgramBai5();
                        bai5.History();
                        break;
                    case 6:
                        var bai6 = new ProgramBai6();
                        bai6.History();
                        break;
                    case 7:
                        var bai7 = new ProgramBai7();
                        bai7.History();
                        break;
                    case 8:
                        var bai8 = new ProgramBai8();
                        bai8.History();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("co loi doc file: ");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        static void bai10()
        {

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY BAI TAP C#");
                Console.WriteLine("*************************MENU**************************");
                Console.WriteLine("**  1. Bai 1.Tinh chu vi hình chu nhat               **");
                Console.WriteLine("**  2. Bai 2.In day so Fibonacci                     **");
                Console.WriteLine("**  3. Bai 3.Kiem tra so nguyên to                   **");
                Console.WriteLine("**  4. Bai 4.Kiem tra so đoi xung                    **");
                Console.WriteLine("**  5. Bai 5.Đao nguoc mot so va mot chuoi           **");
                Console.WriteLine("**  6. Bai 6.Kiem tra so Armstrong                   **");
                Console.WriteLine("**  7. Bai 7.Tinh giai thua cua mot so               **");
                Console.WriteLine("**  8. Bai 8.Tinh tong cac chu so                    **");
                Console.WriteLine("**  0. Exits                                         **");
                Console.WriteLine("**  9. Chon bai de in ra lich su bai da nhap         **");
                Console.WriteLine("*******************************************************");
                Console.Write("Nhap tuy chon: ");
                int choice = 0;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Nhap sai, yêu cau nhap lai:");
                }
                switch (choice)
                {
                    case 1:
                        bai1();
                        break;
                    case 2:
                        bai2();
                        break;
                    case 3:
                        bai3();
                        break;
                    case 4:
                        bai4();
                        break;
                    case 5:
                        bai5();
                        break;
                    case 6:
                        bai6();
                        break;
                    case 7:
                        bai7();
                        break;
                    case 8:
                        bai8();
                        break;
                    case 0:
                        Console.WriteLine("\nBan da chon thoat chuong trinh!");
                        return;
                    default:
                        Console.WriteLine("\nKhong co chuc nang nay!");
                        Console.WriteLine("\nHay chon chuc nang trong hop menu.");
                        break;
                    case 9:
                        bai9();
                        break;
                    case 10:
                        bai10();
                        break;
                }
            }
        }
    }
}