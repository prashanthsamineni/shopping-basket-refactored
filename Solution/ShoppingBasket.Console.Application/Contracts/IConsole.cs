namespace ShoppingBasket.ConsoleApplication.Contracts
{
    using System.IO;

    public interface IConsole
    {
        void Write(string line);
        void Write(string line, params object[] parameters);
        void WriteLine(string line);
        void WriteLine(string line, params object[] parameters);
        TextWriter Writer();
    }
}