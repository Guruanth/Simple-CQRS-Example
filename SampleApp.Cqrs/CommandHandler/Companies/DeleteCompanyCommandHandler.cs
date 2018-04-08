using SampleApp.Cqrs.Command.Companies;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.Companies
{
    public class DeleteCompanyCommandHandler : CommandHandlerBase<DeleteCompanyCommand, Company>
    {
        public DeleteCompanyCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(DeleteCompanyCommand command)
        {
            var company = new Company
            {
                Id = command.Id
            };

            Repository.Delete(company);
            SaveChanges();
        }
    }
}