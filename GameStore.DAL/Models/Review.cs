using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameStore.DAL.Models
{
    public class Review:BaseEntity
    {
        public string Comment { get; set; }
        public int? ShopItemId { get; set; }

        public string Username {  get; set; }
        public ShopItem? shopItem { get; set; }
    }
}
