using ShoppingBasket.ConsoleApplication.Contracts;

namespace ShoppingBasket.ConsoleApplication
{
    using System.IO;
    using System;

    public class DefaultConsole : IConsole
    {
        /// <summary>
        /// Writes the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        public void Write(string line)
        {
            Console.Write(line);
        }

        /// <summary>
        /// Writes the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="parameters">The parameters.</param>
        public void Write(string line, params object[] parameters)
        {
            Console.Write(string.Format(line, parameters));
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="line">The line.</param>
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="parameters">The parameters.</param>
        public void WriteLine(string line, params object[] parameters)
        {
            Console.WriteLine(string.Format(line, parameters));
        }

        /// <summary>
        /// Writers this instance.
        /// </summary>
        /// <returns></returns>
        public TextWriter Writer()
        {
            return Console.Out;
        }
    }
}