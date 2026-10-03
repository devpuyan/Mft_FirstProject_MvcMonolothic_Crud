using Microsoft.AspNetCore.Mvc;
using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithicApp.Controllers;

public class PersonController : Controller
{
    private readonly IPersonApplicationService _personApplicationService;
    
    public PersonController(IPersonApplicationService personApplicationService)
    {
        _personApplicationService = personApplicationService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _personApplicationService.GetAllPerson();
        return View(result);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePersonDto createPersonDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createPersonDto);
        }

        await _personApplicationService.PostPerson(createPersonDto);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var dto = await _personApplicationService.GetPersonById(id);
        if (dto is null)
            return NotFound();

        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditPersonDto editPersonDto)
    {
        if (id != editPersonDto.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(editPersonDto);

        await _personApplicationService.PutPerson(editPersonDto);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
    {
        await _personApplicationService.DeletePerson(deletePersonDto);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var person = await _personApplicationService.GetPersonById(id);

        if (person == null)
            return NotFound();

        return View(person);
    }
}