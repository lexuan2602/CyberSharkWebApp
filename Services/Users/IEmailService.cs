using TEST_CRUD.DTO.ViewModel;

namespace TEST_CRUD.Services.Users
{
    public interface IEmailService
    {
        public Task SendEmailToCallback(ResetPasswordRequestViewModel emailAddress);
        public Task ResetPasswordCallback(ResetPasswordViewModel model);
    }
}
