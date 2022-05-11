using DbAccess;
using DbAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnDataGird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DbContext _db;
        //private ObservableCollection<Student> _data;
        public MainWindow()
        {
            InitializeComponent();

            // Create bindings.
            CommandBinding binding;

            binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += SaveCommand_Executed;
            CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Open);
            binding.Executed += OpenCommand;
            CommandBindings.Add(binding);            

            _db = DbContext.GetInstance();
            //_data = new ObservableCollection<Student>(_db.Data);
            DataContext = _db.Data;
        }
        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            _db.LoadData();
            //_data = new ObservableCollection<Student>(_db.Data);
            //DataContext = _data;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {            
            //_db.Data = _data.ToList();
            _db.SaveData();
        }

    }
}
