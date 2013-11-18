using System.ComponentModel.Composition;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ShoppingBasket.Client.Contracts.Properties;
using ShoppingBasket.Framework.Contracts;
using ShoppingBasket.Framework.Extensions;

namespace ShoppingBasket.Client.Contracts.Registrar
{
    [Export(typeof(IRegistrar))]
    public class ClientContractsRegistrar : IRegistrar
    {
        public void Register(WindsorContainer windsorContainer)
        {
            windsorContainer.Register(
                AllTypes.Pick()
                    .FromAssembly(Assembly.GetAssembly(typeof (ClientContractsRegistrarMarker)))
                    .If(f => f.Namespace.Equals("ShoppingBasket.Client.Contracts")));
        }
    }
}
