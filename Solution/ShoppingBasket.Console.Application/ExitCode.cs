namespace ShoppingBasket.ConsoleApplication
{
    /// <summary>
    /// The possible exit codes for the application.
    /// </summary>
    public enum ExitCode
    {
        /// <summary>
        /// Indicates an unexpected failure.
        /// </summary>
        UnexpectedException = -1000,

        /// <summary>
        /// Indicates failure.
        /// </summary>
        InitializationFailure = -1,

        /// <summary>
        /// Indicates success.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Indicates that user entry is wrong.
        /// </summary>
        InputFormatException = -1001,
    }
}
