﻿namespace GameStore.MVC.Areas.Admin.ViewModels.GameVM
{
    public class GameCreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
        public string GameID { get; set; }
        public IFormFile ImgUrl { get; set; }
    }
}