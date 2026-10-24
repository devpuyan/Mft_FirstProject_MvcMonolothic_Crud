using Microsoft.AspNetCore.Mvc;
using MvcMonolithicApp.ApplicationServices.Contracts;
using MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithicApp.Controllers;

public class PersonController : Controller
{

    #region [ - Fields & Constructor - ]
    
    private readonly IPersonApplicationService _personApplicationService;

    public PersonController(IPersonApplicationService personApplicationService)
    {
        _personApplicationService = personApplicationService;
    }

    #endregion

    #region [ - Index() - ]

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _personApplicationService.GetAllPerson();
        return View(result);
    }

    #endregion

    #region [ - Create() - ]

    [HttpGet]
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

        await _personApplicationService.Post(createPersonDto);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region [ - Edit() - ]

    [HttpGet]
    public async Task<IActionResult> Edit(GetPersonDto getPersonDto)
    {
        var person = await _personApplicationService.GetById(getPersonDto);

        if (person is null)
            return NotFound();

        var editPersonDto = new EditPersonDto()
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName
        };

        return View(editPersonDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditPersonDto editPersonDto)
    {
        if (!ModelState.IsValid)
            return View(editPersonDto);

        await _personApplicationService.Put(editPersonDto);

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region [ - Delete() - ]

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
    {
        await _personApplicationService.Delete(deletePersonDto);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region [ - Details() - ]

    [HttpGet]
    public async Task<IActionResult> Details(GetPersonDto getPersonDto)
    {
        var person = await _personApplicationService.GetById(getPersonDto);

        if (person is null)
            return NotFound();

        return View(person);
    }

    #endregion
}
