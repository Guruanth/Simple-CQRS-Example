using SampleApp.Cqrs.Command.Companies;
using SampleApp.Dal.Infrastructure;
using SampleApp.Dal.Models;

namespace SampleApp.Cqrs.CommandHandler.Companies
{
    public class UpdateCompanyCommandHandler : CommandHandlerBase<UpdateCompanyCommand, Company>
    {
        public UpdateCompanyCommandHandler(SampleAppContext context) : base(context)
        {
        }

        protected override void RunCommandInternal(UpdateCompanyCommand command)
        {
            var company = new Company
            {
                Id = command.Id,
                Name = command.CompanyDto.Name
            };

            Repository.Update(company);
            SaveChanges();
        }
    }
}