using SampleApp.Cqrs.Dto;

namespace SampleApp.Cqrs.Command.Companies
{
    public class AddCompanyCommand : ICommand
    {
        public CompanyDto CompanyDto { get; }

        public AddCompanyCommand(CompanyDto companyDto)
        {
            CompanyDto = companyDto;
        }
    }
}