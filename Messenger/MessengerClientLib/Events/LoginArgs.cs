using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClientLib.Events
{
    public class LoginArgs
    {
        public string Username { get; set; }

        public LoginArgs(string username)
        {
            Username = username;
        }
    }
}
