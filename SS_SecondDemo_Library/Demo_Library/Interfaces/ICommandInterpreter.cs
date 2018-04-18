namespace Demo_Library.Interfaces
{
   public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string command);
    }
}