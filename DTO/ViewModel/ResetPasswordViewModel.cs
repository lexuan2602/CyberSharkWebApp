using System.ComponentModel.DataAnnotations;

namespace TEST_CRUD.DTO.ViewModel
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "OTP is required.")]
        public string Otp { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; }
    }
}
