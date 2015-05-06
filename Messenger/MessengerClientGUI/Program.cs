using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessengerClientGUI
{
    
    class Program
    {
        [STAThread]
        private static void Main()
        {
            Application app = new Application();
            // Создание главного окна.
            Window win = new Window();
            // Запуск приложения и отображение главного окна,
            app.Run(win);
        }
    }
}
