using System.ComponentModel.DataAnnotations;

namespace TimeCo.Web.Models;

public class SignInViewModel
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public Guid RoleId { get; set; }
}