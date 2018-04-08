namespace SampleApp.Cqrs.Command.People
{
    public class DeletePersonCommand : ICommand
    {
        public int Id { get; }

        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }
}