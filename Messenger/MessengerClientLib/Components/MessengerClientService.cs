using System;
using System.Collections.Generic;
using System.Linq;
using MessengerClientLib.MessengerServiceReference;
using IMessengerClientService = MessengerClientLib.Interfaces.IMessengerClientService;

namespace MessengerClientLib.Components
{
    public class MessengerClientService : IMessengerClientService
    {
        // сам клиент
        
        public IMessengerCoreService Client;

        public MessengerClientService()
        {
            Client = new MessengerCoreServiceClient();
        }

        public MessengerClientService(IMessengerCoreService client)
        {
            Client = client;
        }

        public static User LoggedUser { get; set; }


        User IMessengerClientService.LoggedUser
        {
            get { return LoggedUser; }
            set { LoggedUser = value; }
        }

        public User SelectedUser { get; set; }
        public List<SeenUser> SeenUserList { get; set; }
        public List<Message> MessagesList { get; set; }
        public List<MessageHistory> MessageHistoriesList { get; set; }
        public void GetUsers(int userId)
        {
            foreach (User user in Client.GetUsers(userId))
            {
                SeenUserList.Add(new SeenUser(user.Id, user.Online, user.Username,
                    (MessagesList == null) ? 0 : MessagesList.Where(mes => mes.SenderId == user.Id).ToList().Count));
            }
        }

        public void Initialize()
        {
            SelectedUser = null;
            SeenUserList = new List<SeenUser>();
            
            MessageHistoriesList = new List<MessageHistory>();
            MessagesList =new List<Message>();

            if (SeenUserList != null)
                foreach (SeenUser user in SeenUserList)
                {
                    MessageHistoriesList.Add(new MessageHistory(user));
                }
        }

        public void ChangeSelectedIndexAction(int index)
        {
            //todo
        }

        public Message GetNextNewMessage()
        {
            var message = MessagesList.First(mes => mes.SenderId == SelectedUser.Id);
            MessagesList.Remove(message);
            return message;
        }

        public void SetLoggedUser(User loggedUser)
        {
            LoggedUser = loggedUser;
        }

        public void SendMessage(Message message)
        {
            Client.SendMessage(message);
        }

        public void GetNewMessages(object sender, EventArgs eventArgs)
        {
            // илья это не я писал это писал блядский решарпер
            foreach (var getted in SeenUserList.Select(user => Client.GetMessages(user.Id, LoggedUser.Id).ToList()))
            {
                MessagesList.AddRange(getted);
            }
        }
    }
}
