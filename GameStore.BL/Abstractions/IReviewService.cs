using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Abstractions
{
    public interface IReviewService
    {
        public void CreateReview(Review review);
        public IEnumerable<Review> GetAllReviews();
    }
}
