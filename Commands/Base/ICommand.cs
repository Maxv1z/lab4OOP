namespace Лаб4.Commands.Base
{
    public interface ICommand
    {
        void Execute();
        string GetCommandInfo();
    }
}