using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.Json;

namespace ConsoleApp1
{
    internal interface IBaiTap
    {
        /// <summary>
        /// Giao diện khi mới vào chương trình
        /// </summary>
        void Welcome();
        /// <summary>
        /// Khai báo giao diện đầu vào
        /// </summary>
        void Input();
        /// <summary>
        /// Logic tính toán
        /// </summary>
        void Process();
        /// <summary>
        /// Tính toán kết quả và trả về kết quả đầu ra
        /// </summary>
        void Output();
        /// <summary>
        /// Xác nhận dữ liệu hợp lệ
        /// </summary>
        bool Validate();
        /// <summary>
        /// Lưu kết quả file
        /// </summary>
        void Save();
        /// <summary>
        /// Xem lịch sử
        /// </summary>
        void History(string searchKey = "");
        /// <summary>
        /// Chờ bấm phím bất kỳ để đi tiếp
        /// </summary>
        void Wait();
        
    }
}
