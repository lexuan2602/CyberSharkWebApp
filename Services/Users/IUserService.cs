
using TEST_CRUD.DTO;
using TEST_CRUD.ViewModel;

namespace TEST_CRUD.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel registerViewModel);

        //jwt String
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
