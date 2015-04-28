using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using MessengerCoreLib.Interfaces;

namespace MessengerCoreLib.Components
{
    public class MessengerCoreService : IMessengerCoreService
    {
        public IUsersStorage DataStore = new DbWork.DataBase();


        /// Вход пользователя в чат

        public User Login(string username)
        {
            try
            {
                return DataStore.Login(username);
            }
            catch (Exception exception)
            {
                if (exception.Message == "A user with the same name already online!")
                    throw new FaultException("A user with the same name already online!");
                throw new FaultException("SERVER WATAFACKING");
            }
        }


        public IEnumerable<User> GetUsers(int userId)
        {
            try
            {
                var userList = DataStore.GetUsers(userId);
                return userList.Where(u => u.Id != userId);
            }
            catch (Exception)
            {
                throw new FaultException("SERVER WATAFACKING");
            }
        }



        public void SendMessage(Message message)
        {
            try
            {
                if (DataStore.IfUserExists(message.SenderId) && DataStore.IfUserExists(message.RecipientId))
                    DataStore.AddMessage(message);
                else
                    throw new FaultException("Not found");
            }
            catch (Exception)
            {
                throw new FaultException("SERVER WATAFACKING");
            }

        }


        public string GetUserName(int userId)
        {
            try
            {
                return DataStore.GetUserName(userId);
            }
            catch (Exception)
            {
                throw new FaultException("SERVER WATAFACKING.");
            }
        }


        public IEnumerable<Message> GetMessages(int sender, int reciever)
        {
            try
            {
                return DataStore.GetMessages(sender, reciever);
            }
            catch (Exception)
            {
                throw new FaultException("SERVER WATAFACKING");
            }
        }
    }
}
