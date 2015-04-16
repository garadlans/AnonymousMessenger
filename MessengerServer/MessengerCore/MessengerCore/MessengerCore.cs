using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MessengerCoreLib;

namespace MessengerCore
{
    class MessengerCore
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(MessengerCoreLib.CoreService)))
            {
                host.Open();
                Console.WriteLine("Host Start line");
            }
        }
    }
}
