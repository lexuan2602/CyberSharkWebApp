using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is a required field.")]
        public string Mat_khau { get; set; } = "";

    }
}
