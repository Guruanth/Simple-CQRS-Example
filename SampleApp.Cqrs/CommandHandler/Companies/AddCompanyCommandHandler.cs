using SampleApp.Cqrs.Command.Companies;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;
using System.Linq;

namespace SampleApp.Cqrs.CommandHandler.Companies
{
    public class AddCompanyCommandHandler : CommandHandlerBase<AddCompanyCommand, Company>
    {
        public AddCompanyCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(AddCompanyCommand command)
        {
            var companyDto = command.CompanyDto;
            DbSet.Add(new Company
            {
                Name = companyDto.Name
            });
        }
    }
}