using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TEST_CRUD.Data;
using TEST_CRUD.Models;
using TEST_CRUD.ViewModel;

namespace TEST_CRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CyberSharkContext _context;
        private readonly IConfiguration _config;

        public UserRepository(CyberSharkContext context, IConfiguration config)
        {
            _context = context;
            //inject config into Repo (jwt seret inside)
            _config = config;
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

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginViewModel.Email);

            if (user != null && VerifyPassword(user.Mat_khau, loginViewModel.Mat_khau))
            {
                // Đăng nhập thành công, tạo JWT token
                var token = GenerateJwtToken(user);
                return token;
            }

            // Đăng nhập thất bại
            throw new ArgumentException("Incorrect email or password. Please try again.");
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
