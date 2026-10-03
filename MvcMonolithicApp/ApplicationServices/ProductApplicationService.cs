using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;
using MvcMonolithicApp.Models.Services.Contracts;

namespace MvcMonolithicApp.ApplicationServices;

public class ProductApplicationService : IProductApplicationService
{
    private readonly IProductRepository _productRepository;

    public ProductApplicationService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    #region GetAllProducts
    public async Task<List<GetProductDto>> GetAllProduct()
    {
        var products = await _productRepository.SelectAll();
        var getProductDtos = new List<GetProductDto>();
        foreach (var item in products)
        {
            var getProductDto = new GetProductDto()
            {
                Id = item.Id,
                ProductName = item.ProductName,
                ProductDescription = item.ProductDescription,
                UnitPrice = item.UnitPrice
            };
            getProductDtos.Add(getProductDto);
        }
        return getProductDtos;
    }
    #endregion
    #region PostProduct

    public async Task PostProduct(CreateProductDto createProductDto)
    {
        var product = new Product()
        {
            ProductName = createProductDto.ProductName,
            ProductDescription = createProductDto.ProductDescription,
            UnitPrice = createProductDto.UnitPrice
        };
        await _productRepository.Insert(product);
    }

    public async Task DeleteProduct(DeleteProductDto deleteProductDto)
    {
        await _productRepository.Delete(deleteProductDto.Id);
    }

    public async Task PutProduct(EditProductDto editProductDto)
    {
        await _productRepository.Edit(editProductDto.Id,editProductDto.ProductName, editProductDto.ProductDescription, editProductDto.UnitPrice);
    }

    public async Task<EditProductDto?> GetProductById(Guid id)
    {
        var product = await _productRepository.GetProductById(id);
        if (product is null)
            return null;
        return new EditProductDto()
        {
            Id = product.Id,
            ProductName = product.ProductName,
            ProductDescription = product.ProductDescription,
            UnitPrice = product.UnitPrice
        };
    }

    #endregion
}