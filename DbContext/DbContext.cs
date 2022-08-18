using DbAccess.Models;
using MiniExcelLibs;

namespace DbAccess
{
    //单例模式
    public sealed class DbContext
    {

        // 定义一个标识确保线程同步
        private static readonly object _locker = new object();

        private static DbContext? _uniqueInstance;
        private readonly string _path;

        public List<Student> Data { get; set; }
        private DbContext()
        {

            _path = $"{AppDomain.CurrentDomain.BaseDirectory}/Data/NameList.xlsx";
            Data = MiniExcel.Query<Student>(_path).ToList();
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static DbContext GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_uniqueInstance == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new DbContext();
                    }
                }
            }
            return _uniqueInstance;
        }


        public void SaveData() => MiniExcel.SaveAs(_path, Data, overwriteFile: true);
        public void LoadData() => Data = MiniExcel.Query<Student>(_path).ToList();
    }
}