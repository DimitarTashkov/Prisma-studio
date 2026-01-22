using HotelOazis.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOazis.Services.Interfaces
{
    public interface IReviewService : IValidateModel
    {
        public Task<bool> CreateReviewAsync(ReviewInputModel model);
        public Task<List<ReviewViewModel>> GetAllReviewsAsync();
        public Task<bool> EditReviewAsync(ReviewEditInputModel model);
        public Task<bool> DeleteReviewAsync(Guid id);

    }
}
