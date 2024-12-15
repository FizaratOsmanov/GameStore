using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Models
{
    public class Game:BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Price {  get; set; }

        public string GameID { get; set; }

        public string Img {  get; set; }

        public IEnumerable<Review> Reviews { get; set; }


    }
}
