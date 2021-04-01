namespace FluiTec.AppFx.Console.Module
{
    /// <summary>   A console module. </summary>
    public interface IConsoleModule : IConsoleMenuItem
    {
        
    }

    public class ConsoleModule : BaseMenuItem, IConsoleModule
    {

    }
}