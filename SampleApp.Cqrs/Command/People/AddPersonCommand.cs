using SampleApp.Cqrs.Dto;

namespace SampleApp.Cqrs.Command.People
{
    public class AddPersonCommand : ICommand
    {
        public PersonDto PersonDto { get; }

        public AddPersonCommand(PersonDto personDto)
        {
            PersonDto = personDto;
        }
    }
}