using SampleApp.Cqrs.Dto;

namespace SampleApp.Cqrs.Command.People
{
    public class UpdatePersonCommand : ICommand
    {
        public int Id { get; }
        public PersonDto PersonDto { get; }

        public UpdatePersonCommand(int id, PersonDto personDto)
        {
            Id = id;
            PersonDto = personDto;
        }
    }
}