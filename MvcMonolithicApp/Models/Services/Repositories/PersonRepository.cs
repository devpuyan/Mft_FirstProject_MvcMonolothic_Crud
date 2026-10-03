using Microsoft.EntityFrameworkCore;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;
using MvcMonolithicApp.Models.Services.Contracts;

namespace MvcMonolithicApp.Models.Services.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public PersonRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    #region [ - SelectAll - ]
    public async Task<List<Person>> SelectAll()
    {
        try
        {
            return await _projectDbContext.Person.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
    
    #region [ - Insert - ]
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

    #region [ - Delete - ]

    public async Task Delete(int id)
    {
        
        try
        {
            var person = await _projectDbContext.Person.FindAsync(id);
            if (person is null)
                throw new KeyNotFoundException($"Person with id {id} not found.");
            _projectDbContext.Person.Remove(person);
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region [ - Edit - ]

    public async Task Edit(int id, string firstName, string lastName)
    {
        try
        {
            var person = await _projectDbContext.Person.FindAsync(id);
            if (person is null)
                throw new KeyNotFoundException($"Person with id {id} not found.");
            person.FirstName = firstName;
            person.LastName = lastName;
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region [ - GetPersonById - ]

    public async Task<Person?> GetById(int id)
    {
        try
        {
            return await _projectDbContext.Person.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
    
}