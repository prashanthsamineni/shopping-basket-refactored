using Castle.Windsor;

namespace ShoppingBasket.Framework.Contracts
{
    public interface IRegistrar
    {
        /// <summary>
        /// Registers the specified windsor container.
        /// </summary>
        /// <param name="windsorContainer">The windsor container.</param>
        void Register(WindsorContainer windsorContainer);
    }
}
