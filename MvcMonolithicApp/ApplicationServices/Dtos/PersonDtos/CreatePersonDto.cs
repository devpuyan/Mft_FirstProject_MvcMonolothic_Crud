using System.ComponentModel.DataAnnotations;

namespace MvcMonolithicApp.ApplicationServices.Dtos.PersonDtos;

public class CreatePersonDto
{
    [Required(ErrorMessage = "Firstname is required")]
    [Display(Name = "FirstName")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Lastname is required")]
    [Display(Name = "LastName")]
    public string LastName { get; set; }
}