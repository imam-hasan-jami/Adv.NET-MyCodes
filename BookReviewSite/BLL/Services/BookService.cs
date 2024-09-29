using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<Author, AuthorWithBooksDTO>().ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
                cfg.CreateMap<Book, BookSummaryDTO>();
            });
            return new Mapper(config);
        }

        public static List<BookDTO> Get()
        {
            /*var data = DataAccess.BookData().Get();
            return GetMapper().Map<List<BookDTO>>(data);*/

            var books = DataAccess.BookData().Get();
            var bookDTOs = GetMapper().Map<List<BookDTO>>(books);

            var recommendations = DataAccess.RecommendationData().Get();

            foreach (var bookDTO in bookDTOs)
            {
                // Filter recommendations for the current book
                var bookRecommendations = recommendations.Where(r => r.BookId == bookDTO.BookId).ToList();

                // Count recommended and not recommended
                bookDTO.RecommendedCount = bookRecommendations.Count(r => r.IsRecommended);
                bookDTO.NotRecommendedCount = bookRecommendations.Count(r => !r.IsRecommended);
            }

            return bookDTOs;
        }

        public static BookDTO Get(int id)
        {
            /*var data = DataAccess.BookData().Get(id);
            return GetMapper().Map<BookDTO>(data);*/

            var book = DataAccess.BookData().Get(id);
            var bookDTO = GetMapper().Map<BookDTO>(book);

            var recommendations = DataAccess.RecommendationData().Get().Where(r => r.BookId == id).ToList();

            // Count recommended and not recommended
            bookDTO.RecommendedCount = recommendations.Count(r => r.IsRecommended);
            bookDTO.NotRecommendedCount = recommendations.Count(r => !r.IsRecommended);

            return bookDTO;
        }

        public static bool Create(BookDTO obj)
        {
            var data = GetMapper().Map<Book>(obj);
            return DataAccess.BookData().Create(data) != null;
        }

        public static bool Update(BookDTO obj)
        {
            var data = GetMapper().Map<Book>(obj);
            return DataAccess.BookData().Update(data) != null;
        }

        public static bool Delete(int id)
        {
            return DataAccess.BookData().Delete(id);
        }
    }
}
