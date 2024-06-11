using AutoMapper;
using JMMinistry.Common.Dtos.Class;
using JMMinistry.Common.Dtos.School;
using JMMinistry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Mappers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            //CreateMap<PersonalInfo, Prof>


            CreateMap<School, SchoolDto>();
            CreateMap<School, SchoolWithClassesDto>();

            CreateMap<Class, ClassDto>();
        }
    }
}
