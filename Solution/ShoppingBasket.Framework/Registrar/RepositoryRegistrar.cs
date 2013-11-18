using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ShoppingBasket.Framework.Contracts;
using ShoppingBasket.Framework.Extensions;
using ShoppingBasket.Framework.Properties;

namespace ShoppingBasket.Framework.Registrar
{
    [Export(typeof(IRegistrar))]
    public class RepositoryRegistrar : IRegistrar
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(WindsorContainer container)
            {
                container.Register(
                    AllTypes.Pick().FromAssembly(Assembly.GetAssembly(typeof(FrameworkMarker)))
                        .If(t => t.Name.EndsWith("Repository", StringComparison.InvariantCultureIgnoreCase))
                        .WithService.FirstNonGenericCoreInterface("ShoppingBasket.Framework"));
            }
    }
}
