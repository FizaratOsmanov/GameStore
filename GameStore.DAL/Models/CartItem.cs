using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Models
{
    public class CartItem:BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GameId { get; set; }
        public decimal Price { get; set; }

        public string ImgPath { get; set; }
        public int Quantity { get; set; }
    }
}
