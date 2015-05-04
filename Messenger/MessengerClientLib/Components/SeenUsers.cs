using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Components
{

    [Serializable]
    public class SeenUser : User
    {
        public static SeenUser From(User user)
        {
            return new SeenUser(user.Id,user.Online,user.Username, 0);
        }

        public SeenUser(int id, bool online, string name, int countOfnewMessages)
        {
            Id = id;
            Online = online;
            Username = name;
            NewestMessgesCount = countOfnewMessages;
        }

        public override string ToString()
        {
            var status = Online ? "<-Online->" : "<!Disonline!> " + "[" + NewestMessgesCount + "]";
            return string.Format("SeenUser id: {0} username: {1}{2}", Id, Username, status);
        }

        public int NewestMessgesCount { get; set; }
    }
}
