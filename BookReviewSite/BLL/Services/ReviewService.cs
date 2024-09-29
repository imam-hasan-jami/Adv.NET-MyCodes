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
                //cfg.CreateMap<Review, ReviewWithAuthorBookDTO>().ForMember(dest => dest.ReviewDetailss, opt => opt.MapFrom(src => src.Authors));
                //cfg.CreateMap<Review, ReviewWithAuthorBookDTO>().ForMember(dest => dest.ReviewDetailss, opt => opt.MapFrom(src => src.Books));
                cfg.CreateMap<Review, ReviewDetailsDTO>();
                //cfg.CreateMap<ReviewDetailsDTO, Review>();
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<Book, BookDTO>();
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

        /*public static List<ReviewDetailsDTO> GetReviewDetails()
        {
            var repo = DataAccess.ReviewData();
            var reviews = repo.Get();
            var mapper = GetMapper();

            var reviewDetails = reviews.Select(review => new ReviewDetailsDTO
            {
                BookTitle = review.Book.Title,
                AuthorName = review.Book.Author.Name,
                AuthorId = review.Book.AuthorId,
                ReviewText = review.ReviewText,
                Rating = review.Rating
            }).ToList();

            return reviewDetails;
        }*/

        /*public static ReviewDetailsDTO GetReviewDetails(int id)
        {
            var data = DataAccess.ReviewData().Get(id);
            return GetMapper().Map<ReviewDetailsDTO>(data);
        }*/

        /*public static ReviewWithAuthorBookDTO GetReviewsWithAuthorBook(int reviewId)
        {
            var review = DataAccess.ReviewData().Get(reviewId);
            return GetMapper().Map<ReviewWithAuthorBookDTO>(review);
        }*/

        public static ReviewDetailsDTO GetReviewDetails(int reviewId)
        {
            var review = DataAccess.ReviewData().Get(reviewId);
            if (review == null)
            {
                return null; // Handle case where review is not found
            }

            // Fetch book and author related to the review
            var book = DataAccess.BookData().Get(review.BookId);
            var author = DataAccess.AuthorData().Get(book.AuthorId);

            // Map the result to ReviewDetailsDTO
            var reviewDetails = new ReviewDetailsDTO
            {
                BookTitle = book.Title,
                AuthorId = author.AuthorId,
                AuthorName = author.Name,
                ReviewText = review.ReviewText,
                Rating = review.Rating
            };

            return reviewDetails;
        }
    }
}
