using HotelOazis.DTOs.Review;
using HotelOazis.Models;
using HotelOazis.Models.DbConfiguration;
using HotelOazis.Models.Enumerations;
using HotelOazis.Services;
using HotelOazis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness.Services
{
    public class ReviewService : BaseService, IReviewService
    {
        private readonly HotelContext _context;

        public ReviewService(HotelContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateReviewAsync(ReviewInputModel model)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Message = model.Message,
                Rating = model.Rating,
                MessageStatus = model.MessageStatus,
                PublishedOn = model.PublishedOn,
                UserId = model.UserId
            };

            await _context.Reviews.AddAsync(review);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ReviewViewModel>> GetAllReviewsAsync()
        {
            return await _context.Reviews.Include(c => c.User)
                .Select(c => new ReviewViewModel
                {
                    Id = c.Id,
                    Messages = c.Message,
                    Rating = c.Rating,
                    MessageStatus = c.MessageStatus,
                    PublishedOn = c.PublishedOn,
                    UserId = c.UserId,
                    Username = c.User.Username,
                    ProfilePicture = c.User.AvatarUrl
                })
                .ToListAsync();
        }

        public async Task<bool> EditReviewAsync(ReviewEditInputModel model)
        {
            var review = await _context.Reviews.FindAsync(model.Id);
            if (review == null) return false;

            review.Message = model.Message;
            review.Rating = model.Rating;
            review.MessageStatus = model.MessageStatus;
            review.PublishedOn = model.PublishedOn;

            _context.Reviews.Update(review);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteReviewAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
