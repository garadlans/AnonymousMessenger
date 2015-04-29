using System.Collections.Generic;

namespace MessengerCoreLib.Interfaces
{
    public interface IUsersStorage
    {
        User Login(string username);

        IEnumerable<User> GetUsers(int userId);

        string GetUserName(int userId);

        IEnumerable<Message> GetMessages(int sender, int reciever);

        bool IfUserExists(int id);

        void AddMessage(Message message);
    }
}
