using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Wachtwoord is verplicht")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}