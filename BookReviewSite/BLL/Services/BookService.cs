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
            });
            return new Mapper(config);
        }

        public static List<BookDTO> Get()
        {
            var data = DataAccess.BookData().Get();
            return GetMapper().Map<List<BookDTO>>(data);
        }

        public static BookDTO Get(int id)
        {
            var data = DataAccess.BookData().Get(id);
            return GetMapper().Map<BookDTO>(data);
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
