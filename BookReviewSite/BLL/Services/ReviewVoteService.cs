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
    public class ReviewVoteService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewVote, ReviewVoteDTO>();
                cfg.CreateMap<ReviewVoteDTO, ReviewVote>();
            });
            return new Mapper(config);
        }

        public static List<ReviewVoteDTO> Get()
        {
            var data = DataAccess.ReviewVoteData().Get();
            return GetMapper().Map<List<ReviewVoteDTO>>(data);
        }

        public static ReviewVoteDTO Get(int id)
        {
            var data = DataAccess.ReviewVoteData().Get(id);
            return GetMapper().Map<ReviewVoteDTO>(data);
        }

        public static bool Create(ReviewVoteDTO obj)
        {
            var data = GetMapper().Map<ReviewVote>(obj);
            return DataAccess.ReviewVoteData().Create(data) != null;
        }

        public static bool Update(ReviewVoteDTO obj)
        {
            var data = GetMapper().Map<ReviewVote>(obj);
            return DataAccess.ReviewVoteData().Update(data) != null;
        }

        public static bool Delete(int id)
        {
            return DataAccess.ReviewVoteData().Delete(id);
        }
    }
}
