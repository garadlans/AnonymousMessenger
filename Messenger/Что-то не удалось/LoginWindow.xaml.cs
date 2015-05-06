using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MessengerClientLib.Events;
using MessengerClientLib.Interfaces;

namespace MessengerClientGUI
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : ILoginWindow
    {
        private readonly Window _application;

        private readonly ApplicationContext _context;
        public LoginWindow(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

       
        private void textBoxLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loggin_button(sender, e);
        }

        public event EventHandler<LoginArgs> LoginAction;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            loggin_button.Enabled = loggin_button.Text != string.Empty;
        }

        private void loggin_button(object sender, RoutedEventArgs e)
        {
            if (TextBox_TextChanged.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Имя пользователя не может быть пустым, содержать только пробелы.");
                TextBox_TextChanged.Text = "";
                return;
            }

            if (LoginAction != null && TextBox_TextChanged.Text.Trim() != string.Empty)
                LoginAction(sender, new LoginArgs(TextBox_TextChanged.Text.Trim()));
        }
    }
}
