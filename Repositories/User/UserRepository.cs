using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TEST_CRUD.Data;
using TEST_CRUD.DTO.CustomerDTO;
using TEST_CRUD.DTO.ViewModel;
using TEST_CRUD.Models;
using TEST_CRUD.Repositories.Customers;
using TEST_CRUD.Services.Customers;
using TEST_CRUD.ViewModel;

namespace TEST_CRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CyberSharkContext _context;
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _config;

        public UserRepository(CyberSharkContext context, IConfiguration config, ICustomerService customerService)
        {
            _context = context;
            //inject config into Repo (jwt seret inside)
            _config = config;
            _customerService = customerService;
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Ten == username);
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            var newUser = new User
            {
                Ten = registerViewModel.Ten,
                Mat_khau = registerViewModel.Mat_khau,
                Email = registerViewModel.Email,
                So_dien_thoai = registerViewModel.So_dien_thoai,
                Hinhanh = registerViewModel.Hinhanh,
                Role = registerViewModel.Role,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (registerViewModel.Role == "customer")
            {
                // Create a new customer and associate it with the user
                var newCustomerDto = new AddCustomerDto
                {
                    Name = registerViewModel.Ten,
                    Email = registerViewModel.Email,
                    Telephone = registerViewModel.So_dien_thoai,
                    Customer_Images = registerViewModel.Hinhanh,
                    Sex = registerViewModel.Sex,
                    Date_Of_Birth = registerViewModel.Date_Of_Birth,
                };

                var customerServiceResponse = await _customerService.Add(newCustomerDto);

                // Check if the customer creation was successful
                if (!customerServiceResponse.Success)
                {
                    // Handle the error, for example, you can throw an exception or return an error response.
                    throw new Exception($"Error creating customer: {customerServiceResponse.Message}");
                }
            }

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }


        public async Task<(User?, string, int)> Login(LoginViewModel loginViewModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginViewModel.Email);

            if (user != null && VerifyPassword(user.Mat_khau, loginViewModel.Mat_khau))
            {
                // Determine if the user is an admin or customer
                var isAdmin = user.Role == "admin";
                int id;

                if (isAdmin)
                {
                    // Find the admin by email
                    var admin = await _context.Administrator.FirstOrDefaultAsync(a => a.Email == user.Email);
                    id = admin?.Id ?? 0;
                }
                else
                {
                    // Find the customer by email
                    var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == user.Email);
                    id = customer?.Id ?? 0;
                }

                // Generate JWT token
                var jwtToken = GenerateJwtToken(user);

                return (user, jwtToken, id);
            }

            return (null, null, 0); // Login failed
        }


        public string GenerateJwtToken(User user)
        {
            try
            {
                var key = GenerateSecurityKey();
                var tokenHandler = new JwtSecurityTokenHandler();

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
            // Add other claims as needed
        };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return jwtToken;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("Error generating JWT token", ex);
            }
        }

        private byte[] GenerateSecurityKey()
        {
            var key = new byte[32]; // 256 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }

            return key;
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
        private bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            return hashedPassword == HashPassword(enteredPassword);
        }

        public async Task<bool> ResetPassword(string email, string newPassword)
        {
            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                // Update the user's password
                user.Mat_khau = HashPassword(newPassword);
                await _context.SaveChangesAsync();
                return true; // Password reset successful
            }

            return false; // User not found
        }
    }
}
