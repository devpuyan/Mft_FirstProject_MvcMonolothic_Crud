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

    #region [ - GetAllPerson() - ]

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
    
    #endregion

    #region [ - PostPerson() -]

    public async Task PostPerson(CreatePersonDto createPersonDto)
    {
        var person = new Person()
        {
            FirstName = createPersonDto.FirstName,
            LastName = createPersonDto.LastName
        };
        await _personRepository.Insert(person);
    }

    #endregion

    #region [ - DeletePerson() -]

    public async Task DeletePerson(DeletePersonDto deletePersonDto)
    {
        var person = await _personRepository.GetById(deletePersonDto.Id);

        if (person is null)
            return;

        await _personRepository.Delete(person);
    }
    #endregion
    #region [ - PutPerson() -]

    public async Task PutPerson(EditPersonDto editPersonDto)
    {
        var person = await _personRepository.GetById(editPersonDto.Id);

        if (person is null)
            return;

        person.FirstName = editPersonDto.FirstName;
        person.LastName = editPersonDto.LastName;

        await _personRepository.Edit(person);
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