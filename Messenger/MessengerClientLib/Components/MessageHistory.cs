using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Components
{
    public class MessageHistory
    {
        public User User { get; set; }
       
        public string Text { get; set; }

        public MessageHistory(User user)
        {
            User = user;
            Text = "Chatting with [" + User.Username + "] \n";
        }

        public void AddMessage(Message message)
        {
            Text += User.Username + " [" + message.Time + "]: \n" + message.Text + "\n";
        }


        // для своих сообщений
        public void AddMessage(Message message, string usernameLogin)
        {
            Text += usernameLogin + " [" + message.Time + "]: \n" + message.Text + "\n";
        }

    }
}
