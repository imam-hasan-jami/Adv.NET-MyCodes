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

        /*public static bool Create(ReviewDTO obj)
        {
            using (var context = new BContext())
            {
                var userExists = context.Users.Any(u => u.Username == obj.Username);
                if (!userExists)
                {
                    throw new Exception("User does not exist.");
                }

                var data = GetMapper().Map<Review>(obj);
                return DataAccess.ReviewData().Create(data) != null;
            }
        }*/


        public static bool Update(ReviewDTO obj)
        {
            var data = GetMapper().Map<Review>(obj);
            return DataAccess.ReviewData().Update(data) != null;
        }

        public static bool Delete(int id)
        {
            return DataAccess.ReviewData().Delete(id);
        }
    }
}
