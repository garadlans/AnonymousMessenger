using System.Collections.Generic;
using System.ServiceModel;
using MessengerCoreLib.Components;

namespace MessengerCoreLib.Interfaces
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IMessengerCoreService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IMessengerCoreService
    {
        [OperationContract]
        User Login(string username);

        [OperationContract]
        IEnumerable<User> GetUsers(int userId);

        [OperationContract]
        string GetUserName(int userId);

        [OperationContract]
        IEnumerable<Message> GetMessages(int sender, int reciever);

        [OperationContract]
        void SendMessage(Message message);
    }

   
}
