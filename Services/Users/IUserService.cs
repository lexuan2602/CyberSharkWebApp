
using TEST_CRUD.DTO;
using TEST_CRUD.ViewModel;

namespace TEST_CRUD.Services
{
    public interface IUserService
    {
        public Task<User?> Register(RegisterViewModel registerViewModel);

        //jwt String
        public Task<(User?, string, int)> Login(LoginViewModel loginViewModel);
    }
}
