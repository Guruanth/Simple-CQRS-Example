namespace SampleApp.Cqrs.Command.Companies
{
    public class DeleteCompanyCommand : ICommand
    {
        public int Id { get; }

        public DeleteCompanyCommand(int id)
        {
            Id = id;
        }
    }
}