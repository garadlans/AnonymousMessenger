using System;
using System.ServiceModel;
using MessengerCoreLib;

namespace MessengerCore
{
    class MessengerCore
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CoreService)))
            {
                host.Open();
                Console.WriteLine("Host Start line");
                Console.ReadLine();
            }
        }
    }
}
