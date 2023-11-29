using System.Text.Json;
using System.Text;
using TEST_CRUD.DTO.ViewModel;
using TEST_CRUD.Repositories;

namespace TEST_CRUD.Services.Users
{
    public class EmailService : IEmailService
    {
        private readonly IUserRepository _userRepository;

        public EmailService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task SendEmailToCallback(ResetPasswordRequestViewModel Request)
        {

            // Check if the email exists in the database
            var user = await _userRepository.GetByEmail(Request.Email);
            if (user == null)
            {
                throw new ArgumentException("Email not found in the database.");
            }
            string callbackUrl = "https://open-sg.larksuite.com/anycross/trigger/callback/MDgxYzdiNTFlMzViOGUzMjg5ODJjY2RlYTg1NmY2NTRi";

            // Create a simple HTTP client
            using (HttpClient httpClient = new HttpClient())
            {
                // Prepare the content for the POST request
                var content = new StringContent(Request.Email, Encoding.UTF8, "text/plain");

                // Make a POST request to the callback URL
                HttpResponseMessage response = await httpClient.PostAsync(callbackUrl, content);

                // Check if the request was successful (you may want to handle different status codes accordingly)
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task ResetPasswordCallback(ResetPasswordViewModel model)
        {
            string secondCallbackUrl = "https://open-sg.larksuite.com/anycross/trigger/callback/MGY5YjI0MTdlNjJmZGVmZDFkMjNlNjhjNmYxMzBlNGI3";


            using (HttpClient httpClient = new HttpClient())
            {
                // Prepare the content for the POST request
                var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

                // Make a POST request to the second callback URL
                HttpResponseMessage response = await httpClient.PostAsync(secondCallbackUrl, content);

                // Check if the request was successful (you may want to handle different status codes accordingly)
                response.EnsureSuccessStatusCode();
            }

            await _userRepository.ResetPassword(model.Email, model.NewPassword);
        }
    }
}
