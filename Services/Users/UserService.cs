using TEST_CRUD.ViewModel;
using TEST_CRUD.Repositories;


namespace TEST_CRUD.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Register(RegisterViewModel registerViewModel)
        {
            await CheckExistingEmail(registerViewModel.Email);

            // If CheckExistingEmail passes, proceed with registration
            registerViewModel.Mat_khau = HashPassword(registerViewModel.Mat_khau);

            // Call the repository to create the user

            return await _userRepository.Create(registerViewModel);
        }

        private async Task CheckExistingEmail(string email)
        {
            var existingUser = await _userRepository.GetByEmail(email);
            if (existingUser != null)
            {
                throw new ArgumentException("Email already exists");
            }
        }

        // Other methods (e.g., CheckExistingUsername, additional business logic) can be added similarly.

        public async Task<(User?, string, int)> Login(LoginViewModel loginViewModel)
        {
            var (user, jwtToken, id) = await _userRepository.Login(loginViewModel);

            if (user != null && !string.IsNullOrEmpty(jwtToken))
            {
                return (user, jwtToken, id);
            }

            throw new ArgumentException("Incorrect email or password. Please try again.");
        }


        private string HashPassword(string password)
        {
            // In a real system, you should use a secure password hashing library like BCrypt or Identity
            // Here is a simple example using SHA256 for demonstration purposes (not secure for production)
            using (var sha256 = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }


    }
}
