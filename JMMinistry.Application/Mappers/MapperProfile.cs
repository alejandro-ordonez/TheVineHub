using AutoMapper;
using JMMinistry.Application.Extensions;
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
                .ForMember(x => x.Document, cfg => cfg.MapFrom(model => model.Id))
                .ForMember(x => x.Birthday, cfg => cfg.MapFrom(model => model.Birthday.ToDateTime()));

            CreateMap<UserInfoDto, PersonalInfo>()
                .ForMember(model => model.Id, cfg => cfg.MapFrom(x => x.Document))
                .ForMember(model => model.Birthday, cfg => cfg.MapFrom(x => DateOnly.FromDateTime(x.Birthday)));

            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>();

            CreateMap<School, SchoolWithClassesDto>();

            CreateMap<Class, ClassDto>();

            CreateMap<Cell, CellDto>();
            CreateMap<CreateCellDto, Cell>();
        }
    }
}
