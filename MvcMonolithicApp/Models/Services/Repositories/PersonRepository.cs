using Microsoft.EntityFrameworkCore;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;
using MvcMonolithicApp.Models.Services.Contracts;

namespace MvcMonolithicApp.Models.Services.Repositories;

public class PersonRepository : IPersonRepository
{
    #region [ - Fields & Constructor - ]

    private readonly ProjectDbContext _projectDbContext;

    public PersonRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    #endregion

    #region [ - SelectAll() - ]

    public async Task<List<Person>> SelectAll()
    {
        try
        {
            return await _projectDbContext.Person.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion
    
    #region [ - Insert() - ]

    public async Task Insert(Person person)
    {
        try
        {
            _projectDbContext.Person.Add(person);
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region [ - Delete() - ]

    public async Task Delete(Person person)
    {
        try
        {
            var foundPerson = await _projectDbContext.Person.FindAsync(person.Id);
            if (foundPerson is null)
                throw new KeyNotFoundException($"Person with id {person.Id} not found.");
            
            _projectDbContext.Person.Remove(foundPerson);
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion

    #region [ - Edit() - ]

    public async Task Edit(Person person)
    {
        try
        {
            var foundPerson = await _projectDbContext.Person.FindAsync(person.Id);
            if (foundPerson is null)
                throw new KeyNotFoundException($"Person with id {person.Id} not found.");
            
            foundPerson.FirstName = person.FirstName;
            foundPerson.LastName = person.LastName;
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion

    #region [ - GetById() - ]

    public async Task<Person?> GetById(Person person)
    {
        try
        {
            return await _projectDbContext.Person.FindAsync(person.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion
}
