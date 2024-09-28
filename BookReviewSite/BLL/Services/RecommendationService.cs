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
    public class RecommendationService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recommendation, RecommendationDTO>();
                cfg.CreateMap<RecommendationDTO, Recommendation>();
            });
            return new Mapper(config);
        }

        public static List<RecommendationDTO> Get()
        {
            var data = DataAccess.RecommendationData().Get();
            return GetMapper().Map<List<RecommendationDTO>>(data);
        }

        public static RecommendationDTO Get(int id)
        {
            var data = DataAccess.RecommendationData().Get(id);
            return GetMapper().Map<RecommendationDTO>(data);
        }

        public static bool Create(RecommendationDTO obj)
        {
            var data = GetMapper().Map<Recommendation>(obj);
            return DataAccess.RecommendationData().Create(data) != null;
        }

        public static bool Update(RecommendationDTO obj)
        {
            var data = GetMapper().Map<Recommendation>(obj);
            return DataAccess.RecommendationData().Update(data) != null;
        }

        public static bool Delete(int id)
        {
            return DataAccess.RecommendationData().Delete(id);
        }
    }
}
