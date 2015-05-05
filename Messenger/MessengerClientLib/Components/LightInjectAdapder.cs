using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MessengerClientLib.Common;

namespace MessengerClientLib.Components
{
    public class LightInjectAdapder : IContainer
    {
        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            //TODO
        }

        public void Register<TService>()
        {
            //TODO
        }

        public void RegisterInstance<T>(T instance)
        {
            //TODO
        }

        public TService Resolve<TService>()
        {
            //TODO
        }

        public bool IsRegistered<TService>()
        {
            //TODO
        }

        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            //TODO
        }
    }
}
