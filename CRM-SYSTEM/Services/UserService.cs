using CRM_SYSTEM.CustomExceptions;
using CRM_SYSTEM.DTO.Users;
using CRM_SYSTEM.Models;
using CRM_SYSTEM.Repositories;
using System.Net.Mail;
using System.Security.Claims;
using System.Xml.Linq;

namespace CRM_SYSTEM.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public UserResponse Login(LoginRequest request)
        {
            var user = userRepository.GetByLogin(request.login);

            if (user == null)
                throw new UserNotFoundException();

            if (user.password != request.password)
                throw new InvalidPasswordException();

            return new UserResponse
            {
                id = user.id,
                login = user.login,
                fullName = $"{user.name} {user.surname}",
                phone = user.phone,
                email = user.email
            };
        }
        public UserResponse Register(RegisterRequest request)
        {
            var existing = userRepository.GetByLogin(request.login);
            if (existing != null)
                throw new UserAlreadyExistsException($"Login '{request.login}' already taken");

            try
            {
                var addr = new MailAddress(request.email);
                if (addr.Address != request.email) 
                    throw new MailNotCorrectException($"Invalid email format: '{request.email}'");
            }
            catch (FormatException)
            {
                throw new MailNotCorrectException($"Invalid email format: '{request.email}'");
            }

            var hashedPassword = request.password;//BCrypt.Net.BCrypt.HashPassword(request.password);

            var newUser = new Users
            {
                name = request.name,
                surname = request.surname,
                email = request.email,
                phone = request.phone,
                login = request.login,
                password = hashedPassword,
                created_at = DateTime.UtcNow,
                role_id = 1
            };

            userRepository.Add(newUser);

            return new UserResponse     
            {   
                fullName = $"{newUser.name} {newUser.surname}",
                id = newUser.id,
                login = newUser.login,
                phone = newUser.phone,  
                email = newUser.email,
            };
        }
        public UpdatedResponse Update(int userId,UpdateRequest request)
        {
            var user = userRepository.GetById(request.id);  

            if (user == null)
                throw new UserNotFoundException();

            if (!string.IsNullOrEmpty(request.name)) user.name = request.name;

            if (!string.IsNullOrEmpty(request.surname)) user.surname = request.surname;

            if (!string.IsNullOrEmpty(request.password)) user.password = request.password;//BCrypt.Net.BCrypt.HashPassword(request.password);

            userRepository.Update();

            return new UpdatedResponse
            {
                id = user.id,
                name = user.name,
                surname = user.surname
            };
        }
    }
}
