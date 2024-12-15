using System.ComponentModel.DataAnnotations;

namespace GameStore.MVC.Areas.Admin.ViewModels.UserVM
{
    public class UserSignInVM
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsPersistant { get; set; }
    }
}
