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
            var data = DataAccess.ReviewData().Get();
            return GetMapper().Map<List<ReviewDTO>>(data);
        }

        public static ReviewDTO Get(int id)
        {
            var data = DataAccess.ReviewData().Get(id);
            return GetMapper().Map<ReviewDTO>(data);
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

            var reviewDetails = new ReviewDetailsDTO
            {
                BookTitle = book.Title,
                AuthorId = author.AuthorId,
                AuthorName = author.Name,
                ReviewText = review.ReviewText,
                Rating = review.Rating,
                Username = user.Username,
                Name = user.Name
            };

            return reviewDetails;
        }
    }
}
