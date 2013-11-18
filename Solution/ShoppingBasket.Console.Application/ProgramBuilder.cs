using System;
using System.ComponentModel.Composition.Hosting;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Framework.Contracts;

namespace ShoppingBasket.ConsoleApplication
{
    public static class ProgramBuilder
    {
        /// <summary>
        /// Builds the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static Program Build(string[] args)
        {
            InitializeServiceLocator();
            var productTasks = ServiceLocator.Current.GetInstance<IProductTasks>();
            var shoppingCartTasks = ServiceLocator.Current.GetInstance<IShoppingCartTasks>();
            var voucherTasks = ServiceLocator.Current.GetInstance<IVoucherTasks>();
            var defaultConsole = new DefaultConsole();
            return new Program(defaultConsole, productTasks, shoppingCartTasks, voucherTasks);
        }

        /// <summary>
        /// The initialize service locator.
        /// </summary>
        private static void InitializeServiceLocator()
        {
            var windsorContainer = new WindsorContainer();
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(windsorContainer));

            var directoryCatalog = new DirectoryCatalog(Environment.CurrentDirectory, "ShoppingBasket.*.dll");

            var compositionContainer = new CompositionContainer(directoryCatalog);

            foreach (var s in compositionContainer.GetExports<IRegistrar>())
            {
                s.Value.Register(windsorContainer);
            }
        }
    }
}