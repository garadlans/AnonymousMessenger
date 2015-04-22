using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MessengerCoreLib.WorkWithBase;

namespace MessengerCoreLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "MessengerCoreService" в коде и файле конфигурации.
    public class MessengerCoreService : IMessengerCoreService
    {

        public IUsersStorage DataStore = new DataBase();


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
