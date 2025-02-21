using AutoMapper;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Class;
using JMMinistry.Common.Dtos.School;
using JMMinistry.Common.Dtos.User;
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
            CreateMap<PersonalInfo, UserInfoDto>()
                .ForMember(x => x.Document, cfg => cfg.MapFrom(model => model.Id));

            CreateMap<UserInfoDto, PersonalInfo>()
                .ForMember(x => x.Id, cfg => cfg.MapFrom(model => model.Document));

            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>();

            CreateMap<School, SchoolWithClassesDto>();

            CreateMap<Class, ClassDto>();

            CreateMap<Cell, CellDto>();
            CreateMap<CreateCellDto, Cell>();
        }
    }
}
