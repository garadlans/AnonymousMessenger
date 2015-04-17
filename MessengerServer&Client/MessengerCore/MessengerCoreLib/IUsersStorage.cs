using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerCoreLib
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
