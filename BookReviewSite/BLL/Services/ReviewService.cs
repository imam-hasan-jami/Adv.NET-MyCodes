using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReviewService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Review, ReviewDTO>();
                cfg.CreateMap<ReviewDTO, Review>();
                cfg.CreateMap<Review, ReviewDetailsDTO>();
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<User, UserDTO>();
            });
            return new Mapper(config);
        }

        public static List<ReviewDTO> Get()
        { 
            var reviews = DataAccess.ReviewData().Get();
            var reviewDTOs = GetMapper().Map<List<ReviewDTO>>(reviews);

            var votes = DataAccess.ReviewVoteData().Get();

            foreach (var reviewDTO in reviewDTOs)
            {
                reviewDTO.UpvoteCount = votes.Count(v => v.ReviewId == reviewDTO.ReviewId && v.IsUpvote);
                reviewDTO.DownvoteCount = votes.Count(v => v.ReviewId == reviewDTO.ReviewId && !v.IsUpvote);
            }

            return reviewDTOs;
        }

        public static ReviewDTO Get(int id)
        {
            /*var data = DataAccess.ReviewData().Get(id);
            return GetMapper().Map<ReviewDTO>(data);*/

            var review = DataAccess.ReviewData().Get(id);

            // Map the review to ReviewDTO
            var reviewDTO = GetMapper().Map<ReviewDTO>(review);

            // Get all votes for the specific review
            var votes = DataAccess.ReviewVoteData().Get().Where(v => v.ReviewId == id).ToList();

            // Count the upvotes and downvotes
            reviewDTO.UpvoteCount = votes.Count(v => v.IsUpvote);
            reviewDTO.DownvoteCount = votes.Count(v => !v.IsUpvote);

            return reviewDTO;
        }

        public static bool Create(ReviewDTO obj)
        {
            var data = GetMapper().Map<Review>(obj);
            return DataAccess.ReviewData().Create(data) != null;
        }

        public static bool Update(ReviewDTO obj)
        {
            var data = GetMapper().Map<Review>(obj);
            return DataAccess.ReviewData().Update(data) != null;
        }

        public static bool Delete(int id)
        {
            return DataAccess.ReviewData().Delete(id);
        }

        public static ReviewDetailsDTO GetReviewDetails(int reviewId)
        {
            var review = DataAccess.ReviewData().Get(reviewId);
            if (review == null)
            {
                return null;
            }

            var book = DataAccess.BookData().Get(review.BookId);
            var author = DataAccess.AuthorData().Get(book.AuthorId);
            var user = DataAccess.UserData().Get(review.Username);
            var votes = DataAccess.ReviewVoteData().Get().Where(v => v.ReviewId == reviewId);
            var upvotes = votes.Count(v => v.IsUpvote);
            var downvotes = votes.Count(v => !v.IsUpvote);

            var reviewDetails = new ReviewDetailsDTO
            {
                BookTitle = book.Title,
                AuthorId = author.AuthorId,
                AuthorName = author.Name,
                ReviewText = review.ReviewText,
                UpvoteCount = upvotes,
                DownvoteCount = downvotes,
                Rating = review.Rating,
                Username = user.Username,
                Name = user.Name
            };

            return reviewDetails;
        }
    }
}
