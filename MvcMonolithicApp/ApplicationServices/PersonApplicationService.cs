using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;
using MvcMonolithicApp.Models.Services.Contracts;

namespace MvcMonolithicApp.ApplicationServices;

public class PersonApplicationService : IPersonApplicationService
{
    private readonly IPersonRepository _personRepository;

    public PersonApplicationService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    #region [ - GetAllPerson - ]

    public async Task<List<GetPersonDto>> GetAllPerson()
    {
        var persons = await _personRepository.SelectAll();
        var getPersonDtos = new List<GetPersonDto>();
        foreach (var item in persons)
        {
            var getPersonDto = new GetPersonDto()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            getPersonDtos.Add(getPersonDto);
        }

        return getPersonDtos;
    }

    public async Task PostPerson(CreatePersonDto createPersonDto)
    {
        var person = new Person()
        {
            FirstName = createPersonDto.FirstName,
            LastName = createPersonDto.LastName
        };
        await _personRepository.Insert(person);
    }

    public async Task DeletePerson(DeletePersonDto deletePersonDto)
    {
        await _personRepository.Delete(deletePersonDto.Id);
    }

    public async Task PutPerson(EditPersonDto editPersonDto)
    {
        await _personRepository.Edit(editPersonDto.Id, editPersonDto.FirstName, editPersonDto.LastName);
    }
    
    #endregion
    
    public async Task<EditPersonDto?> GetPersonById(int id)
    {
        var person = await _personRepository.GetById(id);
        if (person is null)
            return null;

        return new EditPersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName
        };
    }
}