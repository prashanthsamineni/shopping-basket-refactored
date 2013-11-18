using System;
using System.ComponentModel.Composition;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ShoppingBasket.Framework;
using ShoppingBasket.Framework.Contracts;
using ShoppingBasket.Framework.Extensions;
using ShoppingBasket.Tasks.Properties;

namespace ShoppingBasket.Tasks.Registrar
{
    [Export(typeof(IRegistrar))]
    public class TasksRegistrar : IRegistrar
    {
        /// <summary>
        /// Registers the specified windsor container.
        /// </summary>
        /// <param name="windsorContainer">The windsor container.</param>
        public void Register(WindsorContainer windsorContainer)
        {
            windsorContainer.Register(
                    AllTypes.Pick()
                            .FromAssembly(Assembly.GetAssembly(typeof(TasksMarker)))
                            .If(f => f.Namespace.Equals("ShoppingBasket.Tasks"))
                            .WithService.FirstNonGenericCoreInterface("ShoppingBasket.Client.Contracts"));
        }
    }
}
