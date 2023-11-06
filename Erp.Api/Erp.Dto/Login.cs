using Erp.Base.Enum;

namespace Erp.Dto
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public DateTime ExpireDate { get; set; }
        public string Token { get; set; }
        public string User { get; set; }
        public UserRole Role { get; set; }
    }
}
