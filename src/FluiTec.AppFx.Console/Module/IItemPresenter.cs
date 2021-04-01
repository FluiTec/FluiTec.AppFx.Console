namespace FluiTec.AppFx.Console.Module
{
    /// <summary>   Interface for item presenter. </summary>
    public interface IItemPresenter
    {
        /// <summary>   Presents the given item. </summary>
        /// <param name="item"> The item. </param>
        void Present(IConsoleMenuItem item);
    }
}