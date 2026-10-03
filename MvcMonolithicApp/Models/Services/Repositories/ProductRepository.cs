using Microsoft.EntityFrameworkCore;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;
using MvcMonolithicApp.Models.Services.Contracts;

namespace MvcMonolithicApp.Models.Services.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProjectDbContext _projectDbContext;

    public ProductRepository(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    #region [ - SelectAll - ]

    public async Task<List<Product>> SelectAll()
    {
        try
        {
            return await _projectDbContext.Product.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region [ - Insert - ]

    public async Task Insert(Product product)
    {
        try
        {
            _projectDbContext.Add(product);
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

    
    public async Task Delete(Guid id)
    {
        try
        {
            var product = await _projectDbContext.Product.FindAsync(id);
            if (product is null)
                throw new KeyNotFoundException($"Product with id {id} not found.");
            _projectDbContext.Product.Remove(product);
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

    public async Task Edit(Guid id, string productName, string productDescription, decimal unitPrice)
    {
        try
        {
            var product = await _projectDbContext.Product.FindAsync(id);
            if (product is null)
                throw new KeyNotFoundException($"Person with id {id} not found.");
            product.ProductName = productName;
            product.ProductDescription = productDescription;
            product.UnitPrice = unitPrice;
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
    
    #region [ - GetById - ]

    public async Task<Product?> GetProductById(Guid id)
    {
        try
        {
            return await _projectDbContext.Product.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

}