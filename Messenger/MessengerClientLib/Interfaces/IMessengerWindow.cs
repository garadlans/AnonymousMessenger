using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
<<<<<<< HEAD

=======
using MessengerClientLib.Common;
>>>>>>> origin/master
using MessengerClientLib.Components;
using MessengerClientLib.Events;


namespace MessengerClientLib.Interfaces
{
<<<<<<< HEAD
    public interface IMessengerWindow 
=======
    public interface IMessengerWindow : IView
>>>>>>> origin/master
    {
        Label LabelName { get; set; }
        ListBox ListBoxUsers { get; set; }

        TextBox TextBoxMessage { get; set; }

        Button ButtonSendMessage { get; set; }

        RichTextBox RichTextBoxMessages { get; set; }

        event EventHandler<SelectedIndexActionArgs> SelectedIndexAction;

        event EventHandler<SendMessageArgs> SendMessageAction;

        void SetupName(string username);

        void GoChatWithUser(string username, string history);

        void UpdateHistory(string history);

        void RefreshUserList(List<SeenUser> showedUserList, int focusedIndex);

    }
}
