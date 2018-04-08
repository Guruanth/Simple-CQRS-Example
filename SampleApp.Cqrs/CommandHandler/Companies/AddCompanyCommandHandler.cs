using SampleApp.Cqrs.Command.Companies;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.Companies
{
    public class AddCompanyCommandHandler : CommandHandlerBase<AddCompanyCommand, Company>
    {
        public AddCompanyCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(AddCompanyCommand command)
        {
            var company = new Company
            {
                Name = command.CompanyDto.Name
            };

            Repository.Insert(company);
            SaveChanges();
        }
    }
}