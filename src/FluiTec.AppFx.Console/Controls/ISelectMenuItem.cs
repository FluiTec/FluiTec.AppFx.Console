namespace FluiTec.AppFx.Console.Controls
{
    /// <summary>   Interface for select menu item. </summary>
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    public interface ISelectMenuItem<out T>
    {
        /// <summary>   Gets the item. </summary>
        /// <value> The item. </value>
        public T Item { get; }

        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; }

        /// <summary>   Gets the description. </summary>
        /// <value> The description. </value>
        public string Description { get; }
    }
}