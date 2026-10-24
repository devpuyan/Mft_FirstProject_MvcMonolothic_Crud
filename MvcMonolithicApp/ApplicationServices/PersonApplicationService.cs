using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;
using MvcMonolithicApp.Models.Services.Contracts;

namespace MvcMonolithicApp.ApplicationServices;

public class PersonApplicationService : IPersonApplicationService
{
    #region [ - Fields & Constructor - ]

    private readonly IPersonRepository _personRepository;

    public PersonApplicationService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    #endregion

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

    #region [ - Post() - ]

    public async Task Post(CreatePersonDto createPersonDto)
    {
        var person = new Person()
        {
            FirstName = createPersonDto.FirstName,
            LastName = createPersonDto.LastName
        };
        await _personRepository.Insert(person);
    }

    #endregion

    #region [ - Delete() - ]

    public async Task Delete(DeletePersonDto deletePersonDto)
    {
        var personModel = new Person
        {
            Id = deletePersonDto.Id
        };

        var person = await _personRepository.GetById(personModel);

        if (person is null)
            return;

        await _personRepository.Delete(person);
    }

    #endregion
    
    #region [ - Put() - ]

    public async Task Put(EditPersonDto editPersonDto)
    {
        var personModel = new Person
        {
            Id = editPersonDto.Id
        };

        var person = await _personRepository.GetById(personModel);

        if (person is null)
            return;

        person.FirstName = editPersonDto.FirstName;
        person.LastName = editPersonDto.LastName;

        await _personRepository.Edit(person);
    }

    #endregion
    
    #region [ - GetById() - ]

    public async Task<GetPersonDto?> GetById(GetPersonDto getPersonDto)
    {
        var personModel = new Person
        {
            Id = getPersonDto.Id
        };

        var person = await _personRepository.GetById(personModel);

        if (person is null)
            return null;

        return new GetPersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName
        };
    }

    #endregion
}
