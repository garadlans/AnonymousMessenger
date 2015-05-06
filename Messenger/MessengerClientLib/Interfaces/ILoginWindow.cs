using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.Common;
using MessengerClientLib.Events;

namespace MessengerClientLib.Interfaces
{
    public interface ILoginWindow : IView
    {
        event EventHandler<LoginArgs> LoginAction;
    }
}
