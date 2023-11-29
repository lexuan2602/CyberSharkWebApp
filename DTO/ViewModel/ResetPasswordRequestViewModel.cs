using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.ViewModel
{
    public class ResetPasswordRequestViewModel
    {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }
    }
}
