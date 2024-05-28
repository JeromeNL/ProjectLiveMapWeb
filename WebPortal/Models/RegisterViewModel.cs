using System.ComponentModel.DataAnnotations;
using DataAccess.Models;

namespace WebPortal.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Wachtwoord is verplicht")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public List<HolidayResort> Resorts { get; set; }
}