using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameStore.DAL.Models
{
    public class Review:BaseEntity
    {
        public string? Comment { get; set; }
        public int? GameId { get; set; }

        public Game? game { get; set; }
    }
}
