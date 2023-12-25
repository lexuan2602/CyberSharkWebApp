namespace TEST_CRUD.DTO.ViewModel
{
    public class LoginResult
    {
        public User User { get; set; }
        public string JwtToken { get; set; }
        public bool Success { get; set; }
    }
}
