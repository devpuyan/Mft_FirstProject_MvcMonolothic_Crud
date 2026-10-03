using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithicApp.ApplicationServices.Contracts;

public interface IPersonApplicationService
{
    Task<List<GetPersonDto>> GetAllPerson();
    Task PostPerson(CreatePersonDto createPersonDto);
    Task DeletePerson(DeletePersonDto deletePersonDto);
    Task PutPerson(EditPersonDto editPersonDto);
    Task<EditPersonDto?> GetPersonById(int id);

}