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
using MessengerClientLib.Components;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientGUI
{
    /// <summary>
    /// Логика взаимодействия для MessengerWindow.xaml
    /// </summary>
    public partial class MessengerWindow : Window
    {
        private MessengerClientService _client;
        public MessengerWindow(MessengerClientService client, string name)
        {
            _client = client;
            
            InitializeComponent();
            UserNameLabel.Content = name;
            var a = _client.SeenUserList;
            UsersList.ItemsSource = a;

        }

        private void sendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

       

        private void sendBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SendMessageButton.IsEnabled = SendBox.Text != string.Empty;
        }

        private void chatBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MessagesFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }
    }
}
