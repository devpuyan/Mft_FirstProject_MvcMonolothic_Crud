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

    #region [ - SelectAll() - ]

    public async Task<List<Product>> SelectAll()
    {
        try
        {
            return await _projectDbContext.Product.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion

    #region [ - Insert() - ]

    public async Task Insert(Product product)
    {
        try
        {
            _projectDbContext.Add(product);
            await _projectDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    #endregion
    
    #region [ - Delete() - ]

    
    public async Task Delete(Product product)
    {
        try
        {
            var foundProduct = await _projectDbContext.Product.FindAsync(product.Id);
            if (foundProduct is null)
                throw new KeyNotFoundException($"Product with id {product.Id} not found.");
            _projectDbContext.Product.Remove(foundProduct);
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

    public async Task Edit(Product product)
    {
        try
        {
            var foundProduct = await _projectDbContext.Product.FindAsync(product.Id);
            if (foundProduct is null)
                throw new KeyNotFoundException($"Person with id {product.Id} not found.");
            foundProduct.Title = product.Title;
            foundProduct.DescriptionRecord = product.DescriptionRecord;
            foundProduct.UnitPrice = product.UnitPrice;
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