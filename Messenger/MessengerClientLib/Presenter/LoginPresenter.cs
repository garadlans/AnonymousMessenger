using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.Common;
using MessengerClientLib.Components;
using MessengerClientLib.Events;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Presenter
{
    public class LoginPresenter : BasePresenter<ILoginWindow>
    {
        private readonly ILoginClientService _loginService;

        public LoginPresenter(IApplicationController controller, ILoginWindow view, ILoginClientService loginService) : base(controller, view)
        {
            _loginService = new LoginClientService();
            View.LoginAction += RunLogin;
      
        }

        private void RunLogin(object sender, LoginArgs e)
        {
            var logged = _loginService.Login(e.Username);
            if (logged != null)
            {
                  //TODO
//                Controller.Run<MessengerPresenter, User>(logged);
                View.Close();
            }
        }
    }
}
