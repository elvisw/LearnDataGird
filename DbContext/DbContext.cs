using DbAccess.Models;
using MiniExcelLibs;

namespace DbAccess
{
    //单例模式
    public sealed class DbContext
    {
        private static DbContext? _uniqueInstance;
        private readonly string _path;

        public List<Student> Data { get; set; }
        private DbContext()
        {
            
            _path = $"{AppDomain.CurrentDomain.BaseDirectory}/Data/NameList.xlsx";
            Data = MiniExcel.Query<Student>(_path).ToList();
        }

        public static DbContext GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new DbContext();
            }
            return _uniqueInstance;
        }


        public void SaveData() => MiniExcel.SaveAs(_path, Data, overwriteFile: true);
        public void LoadData() => Data = MiniExcel.Query<Student>(_path).ToList();
    }
}