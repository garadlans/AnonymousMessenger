﻿using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Components
{
    public class LoginClientService : ILoginClientService
    {
        public MessengerServiceReference.IMessengerCoreService Client;

        public LoginClientService()
        {
            Client = new MessengerCoreServiceClient();
        }
        public User Login(string loginName)
        {
           return Client.Login(loginName);
        }
    }
}
