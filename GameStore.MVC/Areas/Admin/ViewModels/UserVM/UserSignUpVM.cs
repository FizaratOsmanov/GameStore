using System.ComponentModel.DataAnnotations;

namespace GameStore.MVC.Areas.Admin.ViewModels.UserVM
{
    public class UserSignUpVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string CofirmPassword { get; set; }
    }
}
