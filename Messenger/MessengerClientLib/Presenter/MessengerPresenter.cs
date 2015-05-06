using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.Common;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Presenter
{
    class MessengerPresenter : BasePresenter<IMessengerWindow, User>
    {
        public MessengerPresenter(IApplicationController controller, IMessengerWindow view) : base(controller, view)
        {
        }

        public override void Run(User argument)
        {
            throw new NotImplementedException();
        }
    }
}
