using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TEST_CRUD.DTO;
using TEST_CRUD.DTO.ViewModel;
using TEST_CRUD.Services;
using TEST_CRUD.Services.Users;
using TEST_CRUD.ViewModel;

namespace TEST_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UserController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }
        //https://localhost:port/api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                User? user = await _userService.Register(registerViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                string jwtToken = await _userService.Login(loginViewModel);
                return Ok(new { jwtToken });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("request_resetpassword")]
        public async Task<IActionResult> SendEmail([FromBody] ResetPasswordRequestViewModel Request)
        {
            try
            {
                // Your business logic, validation, etc., can be added here before forwarding the email
                // to the callback URL.

                // Send the email address to the callback URL
                await _emailService.SendEmailToCallback(Request);

                return Ok(new { Message = "Email address sent to successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            try
            {
                // Add logic to validate the OTP and reset the password
                await _emailService.ResetPasswordCallback(new ResetPasswordViewModel
                {
                    Email = model.Email,
                    Otp = model.Otp,
                    NewPassword = model.NewPassword
                });

                // Return a success response
                return Ok(new { Message = "Password reset successful." });
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return BadRequest(new { Message = "Password reset failed.", Error = ex.Message });
            }
        }
    }
}
