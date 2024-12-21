using RazorPageInvontory.Modules.UsersSys.ADL;
using RazorPageInvontory.Modules.UsersSys.Models;

namespace RazorPageInvontory.Modules.UsersSys.BLL
{
    public class AuthenticateUser
    {
        private readonly UserService _userRepository;

        public AuthenticateUser(UserService userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AuthenticateUserAsync(UserLoginRequest user)
        {
            return await _userRepository.ValidateUserAsync(user);
        }
    }
}
