using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerCoreLib.DbWork
{
    public interface IRequester
    {
        DataBaseGetter ExecuteRequest(string request);
    }
}

