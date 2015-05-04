using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Components
{

    [Serializable]
    public class SeenUsers : User
    {
        public SeenUsers(int id, bool online, string name, int newMessagesCount)
        {
            
        }
    }
}
