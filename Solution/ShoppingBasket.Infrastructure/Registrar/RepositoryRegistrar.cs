using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ShoppingBasket.Framework;
using ShoppingBasket.Framework.Contracts;
using ShoppingBasket.Framework.Extensions;
using ShoppingBasket.Infrastructure.Properties;

namespace ShoppingBasket.Infrastructure.Registrar
{
    [Export(typeof(IRegistrar))]
    public class RepositoryRegistrar : IRegistrar
    {
        /// <summary>
        /// Registers the specified windsor container.
        /// </summary>
        /// <param name="windsorContainer">The windsor container.</param>
        public void Register(WindsorContainer windsorContainer)
        {
            windsorContainer.Register(
                    AllTypes.Pick()
                            .FromAssembly(Assembly.GetAssembly(typeof(InfrastructureMarker)))
                            .If(f => f.Namespace.Equals("ShoppingBasket.Infrastructure.Repositories"))
                            .WithService.FirstNonGenericCoreInterface("ShoppingBasket.Tasks"));
        }
    }
}
