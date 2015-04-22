using System;
using System.ServiceModel;
using MessengerCoreLib;
using MessengerCoreLib.WorkWithBase;

namespace MessengerCore
{
    class MessengerCore
    {
        static void Main(string[] args)
        {
            DataBaseLinker.DbName = "Messenger";
            DataBaseLinker.DbHost = "localhost";
            DataBaseLinker.DbUser = "root";
            DataBaseLinker.DbPass = "pass";
            DataBaseLinker.DBPrefix = "";
            
            Console.WriteLine("Running....");

           
            var serviceHost = new ServiceHost(typeof(MessengerCoreService));
            serviceHost.Open();
            Console.WriteLine();
            Console.WriteLine("Messenger service is ready.");
            Console.WriteLine("Press <Enter> to exit.");
            
            

           
            Console.ReadLine();
          
        }
    }
}
