using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MessengerCoreLib.Components;
using MessengerCoreLib.DbWork;
using MessengerCoreLib.Interfaces;

namespace MessengerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseLinker.DbName = "Messenger";
            DataBaseLinker.DbHost = "localhost";
            DataBaseLinker.DbUser = "root";
            DataBaseLinker.DbPass = "1099";
            DataBaseLinker.DbPrefix = "";

            Console.WriteLine("<--SERVER IS STARTING-->");
           
            try
            {
                var serviceHost = new ServiceHost(typeof(MessengerCoreService));
                serviceHost.Open();
                Console.WriteLine("...");
                Console.WriteLine("<--SERVER IS STARTED-->");
                Console.WriteLine("Press <Enter> to exit.");
            }
            catch (Exception)
            {
                Console.WriteLine("<--SERVER IS DONT STARTED-->");
                Console.WriteLine("Press <Enter> to exit.");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
