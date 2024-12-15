using GameStore.BL.Abstractions;
using GameStore.DAL;
using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BL.Concretes
{
    public class ReviewService:IReviewService
    {
        private readonly IEnumerable<Review> _reviews;
        private readonly AppDbContext _appDbContext;
        public ReviewService(AppDbContext appDbContext, IEnumerable<Review> reviews)
        {
            _appDbContext = appDbContext;
            _reviews = reviews;
        }
        public void CreateReview(Review review)
        {
            _appDbContext.Reviews.Add(review);
            int rows = _appDbContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong.");
            }
        }
        public IEnumerable<Review> GetAllReviews()
        {
            IEnumerable<Review> reviews = _appDbContext.Reviews;
            return reviews;
        }
    }
}
