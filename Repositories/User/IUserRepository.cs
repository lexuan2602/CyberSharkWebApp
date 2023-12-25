
using TEST_CRUD.DTO.ViewModel;
using TEST_CRUD.Models;
using TEST_CRUD.ViewModel;

namespace TEST_CRUD.Repositories
{
    public interface IUserRepository
    {
            public Task<User?> GetById(int id);
            public Task<User?> GetByEmail(string email);
            public Task<User?> GetByUsername(string username);
            public Task<User?> Create(RegisterViewModel registerViewModel);
            public Task<(User?, string, int)> Login(LoginViewModel loginViewModel);
            public Task<bool> ResetPassword(string email, string newPassword);
    }
}
