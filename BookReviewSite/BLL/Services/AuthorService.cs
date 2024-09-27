﻿using AutoMapper;
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
    public class AuthorService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<AuthorDTO, Author>();
            });
            return new Mapper(config);
        }

        public static List<AuthorDTO> Get()
        {
            var data = DataAccess.AuthorData().Get();
            return GetMapper().Map<List<AuthorDTO>>(data);
        }

        public static AuthorDTO Get(int id)
        {
            var data = DataAccess.AuthorData().Get(id);
            return GetMapper().Map<AuthorDTO>(data);
        }

        public static bool Create(AuthorDTO obj)
        {
            var data = GetMapper().Map<Author>(obj);
            return DataAccess.AuthorData().Create(data) != null;
        }

        public static bool Update(AuthorDTO obj)
        {
            var data = GetMapper().Map<Author>(obj);
            return DataAccess.AuthorData().Update(data) != null;
        }

        public static bool Delete(int id)
        {
            return DataAccess.AuthorData().Delete(id);
        }
    }
}
