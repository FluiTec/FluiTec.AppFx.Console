namespace FluiTec.AppFx.Console.Presentation
{
    /// <summary>   A console application settings. This class cannot be inherited. </summary>
    public sealed class ConsoleApplicationSettings
    {
        /// <summary>
        ///     Constructor that prevents a default instance of this class from being created.
        /// </summary>
        private ConsoleApplicationSettings()
        {
            Presenter = new DefaultConsolePresenter();
        }

        public IConsolePresenter Presenter { get; set; }

        #region Singleton

        /// <summary>   Gets the instance. </summary>
        /// <value> The instance. </value>
        public static ConsoleApplicationSettings Instance => Nested.InternalInstance;

        // ReSharper disable once ClassNeverInstantiated.Local
        private class Nested
        {
            internal static readonly ConsoleApplicationSettings InternalInstance = new ConsoleApplicationSettings();

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
        }

        #endregion
    }
}