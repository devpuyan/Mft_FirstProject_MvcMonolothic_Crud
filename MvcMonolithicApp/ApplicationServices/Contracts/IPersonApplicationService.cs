using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithicApp.ApplicationServices.Contracts;

public interface IPersonApplicationService
{
    Task<List<GetPersonDto>> GetAllPerson();
    Task Post(CreatePersonDto createPersonDto);
    Task Delete(DeletePersonDto deletePersonDto);
    Task Put(EditPersonDto editPersonDto);
    Task<GetPersonDto?> GetById(GetPersonDto getPersonDto);

}