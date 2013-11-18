using System;
using System.Collections.Generic;

namespace ShoppingBasket.Framework.Extensions
{
    /// <summary>
    /// Extension methods for enumerable collections.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Iterates through each element and applies the specified action.
        /// </summary>
        /// <typeparam name="T">
        /// Collection element Type.
        /// </typeparam>
        /// <param name="items">
        /// The items to iterate through.
        /// </param>
        /// <param name="action">
        /// The action to apply to each element.
        /// </param>
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var local in items)
            {
                action(local);
            }
        }
    }
}