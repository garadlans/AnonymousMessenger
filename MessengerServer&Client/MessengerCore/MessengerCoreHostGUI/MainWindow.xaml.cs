using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using MessengerCoreLib;
using MessengerCoreLib.WorkWithBase;

namespace MessengerCoreHostGUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBaseLinker.DbName = "Messenger";
            DataBaseLinker.DbHost = "localhost";
            DataBaseLinker.DbUser = "root";
            DataBaseLinker.DbPass = "pass";
            DataBaseLinker.DBPrefix = "";


            var serviceHost = new ServiceHost(typeof(MessengerCoreService));
            serviceHost.Open();
        }


    }
}
