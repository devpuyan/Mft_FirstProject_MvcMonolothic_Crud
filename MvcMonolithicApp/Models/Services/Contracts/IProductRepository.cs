using MvcMonolithicApp.Models.DomainModels.ProductAggregate;

namespace MvcMonolithicApp.Models.Services.Contracts;

public interface IProductRepository
{
    Task<List<Product>> SelectAll();
    Task Insert(Product product);
    Task Delete(Guid id);
    Task Edit(Guid id, string productName, string productDescription, decimal unitPrice);
    Task<Product?> GetProductById(Guid id);
}