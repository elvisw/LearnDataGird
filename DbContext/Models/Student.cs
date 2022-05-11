using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Models
{
    public class Student
    {
        public int 学号 { get; set; }
        public string 姓名 { get; set; }
        public 性别枚举 性别 { get; set; }
    }

    public enum 性别枚举
    {
        男,
        女
    }
}
