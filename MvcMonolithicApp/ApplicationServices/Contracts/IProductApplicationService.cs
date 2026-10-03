using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;

namespace MvcMonolithicApp.ApplicationServices.Contracts;

public interface IProductApplicationService
{
    Task<List<GetProductDto>> GetAllProduct();
    Task PostProduct(CreateProductDto createProductDto);
    Task DeleteProduct(DeleteProductDto deleteProductDto);
    Task PutProduct(EditProductDto editProductDto);
    Task<EditProductDto?> GetProductById(Guid id);
}