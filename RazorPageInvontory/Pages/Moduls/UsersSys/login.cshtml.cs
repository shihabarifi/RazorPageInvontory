using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageInvontory.Modules.UsersSys.ADL;
using RazorPageInvontory.Modules.UsersSys.BLL;
using RazorPageInvontory.Modules.UsersSys.Models;

namespace RazorPageInvontory.Pages.Moduls.UsersSys
{
    public class loginModel : PageModel
    {
         private readonly AuthenticateUser _userService;

        //_userService = userService;
        public loginModel(AuthenticateUser _userService)
        {
            this._userService = _userService;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = new UserLoginRequest { username = Username, password = Password };

            if (await _userService.AuthenticateUserAsync(user))
            {
                return RedirectToPage("../Index");
            }

            ErrorMessage = "Invalid username or password.";
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
