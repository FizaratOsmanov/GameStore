using GameStore.DAL.Models;

namespace GameStore.MVC.Areas.Admin.ViewModels.ReviewVM
{
    public class ShowReviewVM
    {
        public int Id { get; set; }
        public ShopItem ShopItem { get; set; }
        public Review Review { get; set; }

    }
}
