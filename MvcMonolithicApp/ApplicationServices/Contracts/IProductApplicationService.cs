using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;
using EditProductDto = MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos.EditProductDto;

namespace MvcMonolithicApp.ApplicationServices.Contracts;

public interface IProductApplicationService
{
    Task<List<GetProductDto>> GetAll();
    Task Post(CreateProductDto createProductDto);
    Task Delete(DeleteProductDto deleteProductDto);
    Task Put(EditProductDto editProductDto);
    Task<GetProductDto?> GetById(GetProductDto getProductDto);
}