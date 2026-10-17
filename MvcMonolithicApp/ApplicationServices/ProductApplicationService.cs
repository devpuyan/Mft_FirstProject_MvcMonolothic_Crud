
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
            var getProductDto = new GetProductDto
            {
                Id = item.Id,
                Title = item.Title,
                DescriptionRecord = item.DescriptionRecord,
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
        var product = new Product
        {
            Title = createProductDto.Title,
            DescriptionRecord = createProductDto.DescriptionRecord,
            UnitPrice = createProductDto.UnitPrice
        };

        await _productRepository.Insert(product);
    }

    #endregion

    #region DeleteProduct

    public async Task DeleteProduct(DeleteProductDto deleteProductDto)
    {
        var product = await _productRepository.GetProductById(deleteProductDto.Id);

        if (product is null)
            return;

        await _productRepository.Delete(product);
    }

    #endregion

    #region PutProduct

    public async Task PutProduct(EditProductDto editProductDto)
    {
        var product = await _productRepository.GetProductById(editProductDto.Id);

        if (product is null)
            return;

        product.Title = editProductDto.Title;
        product.DescriptionRecord = editProductDto.DescriptionRecord;
        product.UnitPrice = editProductDto.UnitPrice;

        await _productRepository.Edit(product);
    }

    #endregion

    #region GetProductById

    public async Task<EditProductDto?> GetProductById(Guid id)
    {
        var product = await _productRepository.GetProductById(id);

        if (product is null)
            return null;

        return new EditProductDto
        {
            Id = product.Id,
            Title = product.Title,
            DescriptionRecord = product.DescriptionRecord,
            UnitPrice = product.UnitPrice
        };
    }

    #endregion
}
