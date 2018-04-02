using SampleApp.Cqrs.Command;

namespace SampleApp.Cqrs.CommandHandler
{
    public interface ICommandHandler<in TParameter> where TParameter : ICommand
    {
        void RunCommand(TParameter command);
    }
}