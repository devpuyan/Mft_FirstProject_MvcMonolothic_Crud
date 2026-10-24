using Microsoft.AspNetCore.Mvc;
using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;

namespace MvcMonolithicApp.Controllers;

public class ProductController : Controller
{
    #region [ - Fields & Constructor - ]

    private readonly IProductApplicationService _productApplicationService;

    public ProductController(IProductApplicationService productApplicationService)
    {
        _productApplicationService = productApplicationService;
    }

    #endregion

    #region [ - Index() - ]

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _productApplicationService.GetAll();
        return View(result);
    }

    #endregion

    #region [ - Create() - ]

    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductDto createProductDto)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }

        await _productApplicationService.Post(createProductDto);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region [ - Edit() - ]

    [HttpGet]
    public async Task<IActionResult> Edit(GetProductDto getProductDto)
    {
        var product = await _productApplicationService.GetById(getProductDto);

        if (product is null)
            return NotFound();

        var editProductDto = new EditProductDto()
        {
            Id = product.Id,
            DescriptionRecord = product.DescriptionRecord,
            UnitPrice = product.UnitPrice
        };

        return View(editProductDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditProductDto editProductDto)
    {
        if (!ModelState.IsValid)
            return View(editProductDto);

        await _productApplicationService.Put(editProductDto);

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region [ - Delete() - ]

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
    {
        await _productApplicationService.Delete(deleteProductDto);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region [ - Details() - ]

    [HttpGet]
    public async Task<IActionResult> Details(GetProductDto getProductDto)
    {
        var product = await _productApplicationService
            .GetById(getProductDto);

        if (product is null)
            return NotFound();

        return View(product);
    }

    #endregion
}
