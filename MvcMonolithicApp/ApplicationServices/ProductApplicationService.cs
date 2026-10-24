using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;
using MvcMonolithicApp.Models.Services.Contracts;
using EditProductDto = MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos.EditProductDto;

namespace MvcMonolithicApp.ApplicationServices;

public class ProductApplicationService : IProductApplicationService
{
    #region [ - Fields & Constructor - ]

    private readonly IProductRepository _productRepository;

    public ProductApplicationService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    #endregion

    #region [ - GetAll() - ]

    public async Task<List<GetProductDto>> GetAll()
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

    #region [ - Post() - ]

    public async Task Post(CreateProductDto createProductDto)
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

    #region [ - Delete() - ]

    public async Task Delete(DeleteProductDto deleteProductDto)
    {
        var productModel = new Product
        {
            Id = deleteProductDto.Id
        };

        var product = await _productRepository.GetProductById(productModel);

        if (product is null)
            return;

        await _productRepository.Delete(product);
    }

    #endregion

    #region [ - Put() - ]

    public async Task Put(EditProductDto editProductDto)
    {
        var productModel = new Product
        {
            Id = editProductDto.Id
        };

        var product = await _productRepository.GetProductById(productModel);

        if (product is null)
            return;

        product.Title = editProductDto.Title;
        product.DescriptionRecord = editProductDto.DescriptionRecord;
        product.UnitPrice = editProductDto.UnitPrice;

        await _productRepository.Edit(product);
    }

    #endregion

    #region [ - GetProductById() - ]

    public Task<GetProductDto?> GetProductById(Guid getProductDto)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region [ - GetById() - ]

    public async Task<GetProductDto?> GetById(GetProductDto getProductDto)
    {
        var productModel = new Product
        {
            Id = getProductDto.Id
        };

        var product = await _productRepository.GetProductById(productModel);

        if (product is null)
            return null;

        return new GetProductDto
        {
            Id = product.Id,
            Title = product.Title,
            DescriptionRecord = product.DescriptionRecord,
            UnitPrice = product.UnitPrice
        };
    }

    #endregion
}
