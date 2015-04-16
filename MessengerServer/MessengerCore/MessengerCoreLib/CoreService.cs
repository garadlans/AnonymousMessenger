using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerCoreLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "CoreService" в коде и файле конфигурации.
    public class CoreService : ICoreService
    {
       

        public User Login(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(int userId)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Message message)
        {
            OperationContext.Current.GetCallbackChannel<ICoreServiceCallBack>().SendMessage(new Message(1,1,"sample", new DateTime()));
        }

        public string GetUserName(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessages(int sender, int reciever)
        {
            throw new NotImplementedException();
        }
    }
}
