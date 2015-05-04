using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.Components;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    public interface IMessengerClientService
    {
        // открытый клиент 
        User LoggedUser { get; set; }

        // пользователь с которым общается логгет узер
        User SelectedUser { get; set; }

        // список пользоавтелей для показа
        List<SeenUser> SeenUserList { get; set; }

        // TODO 
        List<Message> MessagesList { get; set; }

        // TODO 
        List<MessageHistory> MessageHistoriesList { get; set; }

        // TODO 
        void GetUsers(int userId);

        // TODO 
        void Initialize();

        // TODO выделение пользователя
        void ChangeSelectedIndexAction(int index);
        // TODO 
        Message GetNextNewMessage();
        // TODO 
        void SetLoggedUser(User loggedUser);

        void SendMessage(Message message);

        void GetNewMessages(object sender, EventArgs eventArgs);

    }
}
