using Microsoft.AspNetCore.Mvc;
using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;

namespace MvcMonolithicApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductApplicationService _productApplicationService;

    public ProductController(IProductApplicationService productApplicationService)
    {
        _productApplicationService = productApplicationService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var result = await _productApplicationService.GetAllProduct();
        return View(result);
    }

    //Create
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

        await _productApplicationService.PostProduct(createProductDto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var product = await _productApplicationService.GetProductById(id);

        if (product is null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditProductDto editProductDto)
    {
        if (!ModelState.IsValid)
            return View(editProductDto);

        await _productApplicationService.PutProduct(editProductDto);

        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
    {
        await _productApplicationService.DeleteProduct(deleteProductDto);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Details(Guid id)
    {
        var person = await _productApplicationService.GetProductById(id);

        if (person == null)
            return NotFound();

        return View(person);
    }


}