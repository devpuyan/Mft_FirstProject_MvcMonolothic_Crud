using MvcMonolithicApp.Models.DomainModels.PersonAggregate;

namespace MvcMonolithicApp.Models.Services.Contracts;

public interface IPersonRepository
{
    Task<List<Person>> SelectAll();
    Task Insert(Person person);
    Task Delete(Person person);
    Task Edit(Person person);
    Task<Person?> GetById(int id);
}