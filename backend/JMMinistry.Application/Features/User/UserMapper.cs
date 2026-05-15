using JMMinistry.Application.Mappers;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain.Users;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JMMinistry.Application.Features.User
{
    [Mapper]
    [UseStaticMapper(typeof(CommonMapper))]
    internal static partial class UserMapper
    {
        [MapperIgnoreSource(nameof(LeaderInfo.PhotoPath))]
        [MapperIgnoreTarget(nameof(LeaderInfoDto.PhotoUrl))]
        internal static partial LeaderInfoDto ToDto(this LeaderInfo source);

        internal static partial DiscipleDto ToDto(this Disciple source);

        internal static partial IEnumerable<DiscipleDto> ToDtos(this IEnumerable<Disciple> source);
    }
}
