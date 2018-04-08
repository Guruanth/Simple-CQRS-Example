using SampleApp.Cqrs.Dto;

namespace SampleApp.Cqrs.Command.Companies
{
    public class UpdateCompanyCommand : ICommand
    {
        public int Id { get; }
        public CompanyDto CompanyDto { get; }

        public UpdateCompanyCommand(int id, CompanyDto companyDto)
        {
            Id = id;
            CompanyDto = companyDto;
        }
    }
}