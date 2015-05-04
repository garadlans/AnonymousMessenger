using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    // Прослойки
    public interface ILoginClientService
    {
        User Login(string loginName);
    }
}
