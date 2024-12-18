namespace GameStore.MVC.Areas.Admin.ViewModels.BasketVM
{
    public class BasketItemVM
    {
        public int GameId {  get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public IFormFile Img { get; set; }  
    }
}
