using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccess.UserData().Get();
            return GetMapper().Map<List<UserDTO>>(data);
        }

        public static UserDTO Get(string username)
        {
            var data = DataAccess.UserData().Get(username);
            return GetMapper().Map<UserDTO>(data);
        }

        public static bool Create(UserDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Create(data) != null;
        }

        public static bool Update(UserDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Update(data) != null;
        }

        public static bool Delete(string username)
        {
            return DataAccess.UserData().Delete(username);
        }
    }
}
