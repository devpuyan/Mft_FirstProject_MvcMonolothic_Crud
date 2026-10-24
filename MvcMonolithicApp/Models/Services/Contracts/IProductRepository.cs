using MvcMonolithicApp.Models.DomainModels.ProductAggregate;

namespace MvcMonolithicApp.Models.Services.Contracts;

public interface IProductRepository
{
    Task<List<Product>> SelectAll();
    Task Insert(Product product);
    Task Delete(Product product);
    Task Edit(Product product);
    Task<Product?> GetProductById(Product product);
}