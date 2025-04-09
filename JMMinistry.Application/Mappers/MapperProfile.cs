using AutoMapper;
using JMMinistry.Application.Extensions;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Class;
using JMMinistry.Common.Dtos.Gained;
using JMMinistry.Common.Dtos.Meetings;
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

            CreateMap<PersonalInfo, PartialUserInfoDto>()
                .ForMember(x => x.Document, cfg => cfg.MapFrom(model => model.Id));

            CreateMap<UserInfoDto, PersonalInfo>()
                .ForMember(model => model.Id, cfg => cfg.MapFrom(x => x.Document));

            CreateMap<School, SchoolDto>();
            CreateMap<SchoolDto, School>();

            CreateMap<School, SchoolWithClassesDto>();

            CreateMap<Class, ClassDto>();

            CreateMap<Cell, CellDto>();
            CreateMap<CreateCellDto, Cell>();

            CreateMap<CreateGainedUser, PersonalInfo>()
                .ForMember(model => model.Id, cfg => cfg.MapFrom(x => x.Document));

            CreateMap<PersonalInfo, GainedUser>();
            CreateMap<Gained, GainedUser>()
                .IncludeMembers(src => src.Person);

            CreateMap<Domain.GainedEvent, Common.Dtos.Gained.GainedEvent>();

            CreateMap<CreateMeetingDto, Meeting>();
            CreateMap<Meeting, MeetingDto>();
        }
    }
}
