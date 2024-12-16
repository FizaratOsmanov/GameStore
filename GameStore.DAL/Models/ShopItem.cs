using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Models
{
    public class ShopItem :BaseEntity
    {
        public string Title { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public string Img { get; set; }

        public Game game { get; set; }

        public int GameId { get; set; }

        public IEnumerable<Review> Reviews { get; set; }


    }
}
