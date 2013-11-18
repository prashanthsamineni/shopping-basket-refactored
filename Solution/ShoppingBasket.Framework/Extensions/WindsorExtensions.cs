using System;
using System.Linq;
using Castle.MicroKernel.Registration;

namespace ShoppingBasket.Framework.Extensions
{
    /// <summary>
    /// Extension methods for objects that are part of the Castle.Windsor namespace.
    /// </summary>
    public static class WindsorExtensions
    {
        /// <summary>
        /// Searches for the first interface found associated with the
        /// <see cref="ServiceDescriptor"/> which is not generic and which
        /// is found in the specified namespace.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        /// <param name="interfaceNamespace">The interface Namespace.</param>
        /// <returns>A BasedOnDescriptor.</returns>
        public static BasedOnDescriptor FirstNonGenericCoreInterface(
            this ServiceDescriptor descriptor, 
            string interfaceNamespace)
        {
            return descriptor.Select(
                delegate(Type type, 
                         Type baseType)
                    {
                        var interfaces =
                            type.GetInterfaces().Where(
                                t => t.IsGenericType == false && t.Namespace.StartsWith(interfaceNamespace));

                        if (interfaces.Count() > 0)
                        {
                            return new[] { interfaces.ElementAt(0) };
                        }

                        return null;
                    });
        }

        /// <summary>
        /// Searches for the first interface found associated with the
        /// <see cref="ServiceDescriptor"/> which is not generic and which
        /// is found in the specified namespace.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        /// <param name="interfaceNamespaces">The interface namespaces.</param>
        /// <returns>A BasedOnDescriptor.</returns>
        public static BasedOnDescriptor FirstNonGenericCoreInterface(
            this ServiceDescriptor descriptor, 
            params string[] interfaceNamespaces)
        {
            return descriptor.Select(
                (type, baseType) =>
                    {
                        var interfaces =
                            type.GetInterfaces().Where(t => t.IsGenericType == false && interfaceNamespaces.ToList().Any(s => t.Namespace.StartsWith(s)));

                        if (interfaces.Count() > 0)
                        {
                            return new[] { interfaces.ElementAt(0) };
                        }

                        return null;
                    });
        }
    }
}