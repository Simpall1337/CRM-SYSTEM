using CRM_SYSTEM.DTO.Users;

namespace CRM_SYSTEM.Services
{
    public interface IUserService
    {
        public UserResponse Login(LoginRequest request);
        public UserResponse Register(RegisterRequest request);
    }
}
