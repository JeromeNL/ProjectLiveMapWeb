using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Wachtwoord is verplicht")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
}