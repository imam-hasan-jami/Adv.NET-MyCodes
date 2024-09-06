using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PersonService
    {

        static Mapper GetMapper()
        {
            var conf = new MapperConfiguration(cfg => {
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<PersonDTO, Person>();
            });
            return new Mapper(conf);
        }

        public static List<PersonDTO> GetAll()
        {
           /* var data = PersonRepo.Get();
            var conf = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>());
            var mapper = new Mapper(conf);
            return mapper.Map<List<PersonDTO>>(data);*/
            var data = PersonRepo.Get();
            return GetMapper().Map<List<PersonDTO>>(data);
        }

        public static PersonDTO Get(int id)
        {
            /*var data = PersonRepo.Get(id);
            var conf = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>());
            var mapper = new Mapper(conf);
            return mapper.Map<PersonDTO>(data);*/
            throw new NotImplementedException();
            var data = PersonRepo.Get(id);
            return GetMapper().Map<PersonDTO>(data);
        }

        public static bool Create(PersonDTO p)
        {
            /*var data = new Person() { Name = p.Name };
            return PersonRepo.Create(data);*/
            var data = GetMapper().Map<Person>(p);
            return PersonRepo.Create(data);
        }

        public static bool Update(PersonDTO p)
        {
            /*var data = new Person() { Id = p.Id, Name = p.Name };
            return PersonRepo.Update(data);*/
            var data = GetMapper().Map<Person>(p);
            return PersonRepo.Update(data);
        }

        public static bool Delete(int id)
        {
            var data = PersonRepo.Get(id);
            if (data != null)
            {
                PersonRepo.Delete(id);
                return true;
            }
            return false;
        }
    }
}
