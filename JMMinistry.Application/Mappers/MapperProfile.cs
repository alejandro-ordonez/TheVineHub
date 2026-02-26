using System.Text.Json;
using JMMinistry.Common.Dtos.Cell;
using JMMinistry.Common.Dtos.Class;
using JMMinistry.Common.Dtos.Common;
using JMMinistry.Common.Dtos.Discipleship;
using JMMinistry.Common.Dtos.Gained;
using JMMinistry.Common.Dtos.Meetings;
using JMMinistry.Common.Dtos.School;
using JMMinistry.Common.Dtos.User;
using JMMinistry.Domain;
using JMMinistry.Domain.Discipleship;
using JMMinistry.Domain.Location;
using Riok.Mapperly.Abstractions;

namespace JMMinistry.Application.Mappers
{
    [Mapper]
    public partial class AppMapper
    {
        // ===== PersonalInfo <-> UserInfoDto =====

        [MapProperty(nameof(PersonalInfo.Id), nameof(UserInfoDto.Document))]
        [MapperIgnoreSource(nameof(PersonalInfo.UserName))]
        [MapperIgnoreSource(nameof(PersonalInfo.NormalizedUserName))]
        [MapperIgnoreSource(nameof(PersonalInfo.NormalizedEmail))]
        [MapperIgnoreSource(nameof(PersonalInfo.EmailConfirmed))]
        [MapperIgnoreSource(nameof(PersonalInfo.PasswordHash))]
        [MapperIgnoreSource(nameof(PersonalInfo.SecurityStamp))]
        [MapperIgnoreSource(nameof(PersonalInfo.ConcurrencyStamp))]
        [MapperIgnoreSource(nameof(PersonalInfo.PhoneNumber))]
        [MapperIgnoreSource(nameof(PersonalInfo.PhoneNumberConfirmed))]
        [MapperIgnoreSource(nameof(PersonalInfo.TwoFactorEnabled))]
        [MapperIgnoreSource(nameof(PersonalInfo.LockoutEnd))]
        [MapperIgnoreSource(nameof(PersonalInfo.LockoutEnabled))]
        [MapperIgnoreSource(nameof(PersonalInfo.AccessFailedCount))]
        [MapperIgnoreSource(nameof(PersonalInfo.LastAccess))]
        [MapperIgnoreSource(nameof(PersonalInfo.GainedId))]
        [MapperIgnoreSource(nameof(PersonalInfo.GainedRecord))]
        [MapperIgnoreSource(nameof(PersonalInfo.Cell))]
        [MapperIgnoreSource(nameof(PersonalInfo.CellEnrollmentDate))]
        [MapperIgnoreSource(nameof(PersonalInfo.Cells))]
        [MapperIgnoreSource(nameof(PersonalInfo.Gained))]
        [MapperIgnoreSource(nameof(PersonalInfo.MeetingAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.CellAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.ClassAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.Classes))]
        [MapperIgnoreSource(nameof(PersonalInfo.Conventions))]
        [MapperIgnoreSource(nameof(PersonalInfo.ConventionInvites))]
        [MapperIgnoreSource(nameof(PersonalInfo.UserRoles))]
        [MapperIgnoreTarget(nameof(UserInfoDto.AccessType))]
        [MapperIgnoreTarget(nameof(UserInfoDto.Leaders))]
        [MapperIgnoreTarget(nameof(UserInfoDto.Photo))]
        public partial UserInfoDto PersonalInfoToUserInfoDto(PersonalInfo source);

        [MapProperty(nameof(PersonalInfo.Id), nameof(PartialUserInfoDto.Document))]
        [MapperIgnoreSource(nameof(PersonalInfo.UserName))]
        [MapperIgnoreSource(nameof(PersonalInfo.NormalizedUserName))]
        [MapperIgnoreSource(nameof(PersonalInfo.NormalizedEmail))]
        [MapperIgnoreSource(nameof(PersonalInfo.EmailConfirmed))]
        [MapperIgnoreSource(nameof(PersonalInfo.PasswordHash))]
        [MapperIgnoreSource(nameof(PersonalInfo.SecurityStamp))]
        [MapperIgnoreSource(nameof(PersonalInfo.ConcurrencyStamp))]
        [MapperIgnoreSource(nameof(PersonalInfo.PhoneNumber))]
        [MapperIgnoreSource(nameof(PersonalInfo.PhoneNumberConfirmed))]
        [MapperIgnoreSource(nameof(PersonalInfo.TwoFactorEnabled))]
        [MapperIgnoreSource(nameof(PersonalInfo.LockoutEnd))]
        [MapperIgnoreSource(nameof(PersonalInfo.LockoutEnabled))]
        [MapperIgnoreSource(nameof(PersonalInfo.AccessFailedCount))]
        [MapperIgnoreSource(nameof(PersonalInfo.City))]
        [MapperIgnoreSource(nameof(PersonalInfo.Locality))]
        [MapperIgnoreSource(nameof(PersonalInfo.Neighborhood))]
        [MapperIgnoreSource(nameof(PersonalInfo.Address))]
        [MapperIgnoreSource(nameof(PersonalInfo.Email))]
        [MapperIgnoreSource(nameof(PersonalInfo.EducationalLevel))]
        [MapperIgnoreSource(nameof(PersonalInfo.Profession))]
        [MapperIgnoreSource(nameof(PersonalInfo.Occupation))]
        [MapperIgnoreSource(nameof(PersonalInfo.MaritalStatus))]
        [MapperIgnoreSource(nameof(PersonalInfo.Birthday))]
        [MapperIgnoreSource(nameof(PersonalInfo.LastAccess))]
        [MapperIgnoreSource(nameof(PersonalInfo.GainedId))]
        [MapperIgnoreSource(nameof(PersonalInfo.GainedRecord))]
        [MapperIgnoreSource(nameof(PersonalInfo.Cell))]
        [MapperIgnoreSource(nameof(PersonalInfo.CellEnrollmentDate))]
        [MapperIgnoreSource(nameof(PersonalInfo.Cells))]
        [MapperIgnoreSource(nameof(PersonalInfo.Gained))]
        [MapperIgnoreSource(nameof(PersonalInfo.MeetingAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.CellAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.ClassAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.Classes))]
        [MapperIgnoreSource(nameof(PersonalInfo.Conventions))]
        [MapperIgnoreSource(nameof(PersonalInfo.ConventionInvites))]
        [MapperIgnoreSource(nameof(PersonalInfo.UserRoles))]
        [MapperIgnoreTarget(nameof(PartialUserInfoDto.Photo))]
        public partial PartialUserInfoDto PersonalInfoToPartialUserInfoDto(PersonalInfo source);

        [MapProperty(nameof(UserInfoDto.Document), nameof(PersonalInfo.Id))]
        [MapProperty(nameof(UserInfoDto.Document), nameof(PersonalInfo.UserName))]
        [MapperIgnoreSource(nameof(UserInfoDto.AccessType))]
        [MapperIgnoreSource(nameof(UserInfoDto.Leaders))]
        [MapperIgnoreSource(nameof(UserInfoDto.Photo))]
        [MapperIgnoreTarget(nameof(PersonalInfo.NormalizedUserName))]
        [MapperIgnoreTarget(nameof(PersonalInfo.NormalizedEmail))]
        [MapperIgnoreTarget(nameof(PersonalInfo.EmailConfirmed))]
        [MapperIgnoreTarget(nameof(PersonalInfo.PasswordHash))]
        [MapperIgnoreTarget(nameof(PersonalInfo.SecurityStamp))]
        [MapperIgnoreTarget(nameof(PersonalInfo.ConcurrencyStamp))]
        [MapperIgnoreTarget(nameof(PersonalInfo.PhoneNumber))]
        [MapperIgnoreTarget(nameof(PersonalInfo.PhoneNumberConfirmed))]
        [MapperIgnoreTarget(nameof(PersonalInfo.TwoFactorEnabled))]
        [MapperIgnoreTarget(nameof(PersonalInfo.LockoutEnd))]
        [MapperIgnoreTarget(nameof(PersonalInfo.LockoutEnabled))]
        [MapperIgnoreTarget(nameof(PersonalInfo.AccessFailedCount))]
        [MapperIgnoreTarget(nameof(PersonalInfo.LastAccess))]
        [MapperIgnoreTarget(nameof(PersonalInfo.GainedId))]
        [MapperIgnoreTarget(nameof(PersonalInfo.GainedRecord))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Cell))]
        [MapperIgnoreTarget(nameof(PersonalInfo.CellEnrollmentDate))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Cells))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Gained))]
        [MapperIgnoreTarget(nameof(PersonalInfo.MeetingAttendances))]
        [MapperIgnoreTarget(nameof(PersonalInfo.CellAttendances))]
        [MapperIgnoreTarget(nameof(PersonalInfo.ClassAttendances))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Classes))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Conventions))]
        [MapperIgnoreTarget(nameof(PersonalInfo.ConventionInvites))]
        [MapperIgnoreTarget(nameof(PersonalInfo.UserRoles))]
        public partial PersonalInfo UserInfoDtoToPersonalInfo(UserInfoDto source);

        // ===== School mappings =====

        [MapperIgnoreSource(nameof(School.Classes))]
        public partial SchoolDto SchoolToSchoolDto(School source);

        [MapperIgnoreTarget(nameof(School.Classes))]
        public partial School SchoolDtoToSchool(SchoolDto source);

        public partial SchoolWithClassesDto SchoolToSchoolWithClassesDto(School source);

        // ===== Class mappings =====

        [MapperIgnoreSource(nameof(Class.SchoolId))]
        [MapperIgnoreSource(nameof(Class.School))]
        [MapperIgnoreSource(nameof(Class.ClassAttendances))]
        public partial ClassDto ClassToClassDto(Class source);

        // ===== Cell mappings =====

        [MapperIgnoreSource(nameof(Cell.CityId))]
        [MapperIgnoreSource(nameof(Cell.LocalityId))]
        [MapperIgnoreSource(nameof(Cell.Leaders))]
        [MapperIgnoreSource(nameof(Cell.Disciples))]
        public partial CellDto CellToCellDto(Cell source);

        [MapProperty($"{nameof(CellDto.City)}.{nameof(CellDto.City.Id)}", nameof(Cell.CityId))]
        [MapProperty($"{nameof(CellDto.Locality)}.{nameof(CellDto.Locality.Id)}", nameof(Cell.LocalityId))]
        [MapperIgnoreTarget(nameof(Cell.City))]
        [MapperIgnoreTarget(nameof(Cell.Locality))]
        [MapperIgnoreTarget(nameof(Cell.Leaders))]
        [MapperIgnoreTarget(nameof(Cell.Disciples))]
        public partial Cell CellDtoToCell(CellDto source);

        // ===== CreateGainedUser -> PersonalInfo =====

        [MapProperty(nameof(CreateGainedUser.Document), nameof(PersonalInfo.Id))]
        [MapProperty(nameof(CreateGainedUser.Document), nameof(PersonalInfo.UserName))]
        [MapperIgnoreSource(nameof(CreateGainedUser.Petition))]
        [MapperIgnoreSource(nameof(CreateGainedUser.Photo))]
        [MapperIgnoreTarget(nameof(PersonalInfo.NormalizedUserName))]
        [MapperIgnoreTarget(nameof(PersonalInfo.NormalizedEmail))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Email))]
        [MapperIgnoreTarget(nameof(PersonalInfo.EmailConfirmed))]
        [MapperIgnoreTarget(nameof(PersonalInfo.PasswordHash))]
        [MapperIgnoreTarget(nameof(PersonalInfo.SecurityStamp))]
        [MapperIgnoreTarget(nameof(PersonalInfo.ConcurrencyStamp))]
        [MapperIgnoreTarget(nameof(PersonalInfo.PhoneNumber))]
        [MapperIgnoreTarget(nameof(PersonalInfo.PhoneNumberConfirmed))]
        [MapperIgnoreTarget(nameof(PersonalInfo.TwoFactorEnabled))]
        [MapperIgnoreTarget(nameof(PersonalInfo.LockoutEnd))]
        [MapperIgnoreTarget(nameof(PersonalInfo.LockoutEnabled))]
        [MapperIgnoreTarget(nameof(PersonalInfo.AccessFailedCount))]
        [MapperIgnoreTarget(nameof(PersonalInfo.City))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Address))]
        [MapperIgnoreTarget(nameof(PersonalInfo.EducationalLevel))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Profession))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Occupation))]
        [MapperIgnoreTarget(nameof(PersonalInfo.MaritalStatus))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Birthday))]
        [MapperIgnoreTarget(nameof(PersonalInfo.LastAccess))]
        [MapperIgnoreTarget(nameof(PersonalInfo.GainedId))]
        [MapperIgnoreTarget(nameof(PersonalInfo.GainedRecord))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Cell))]
        [MapperIgnoreTarget(nameof(PersonalInfo.CellEnrollmentDate))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Cells))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Gained))]
        [MapperIgnoreTarget(nameof(PersonalInfo.MeetingAttendances))]
        [MapperIgnoreTarget(nameof(PersonalInfo.CellAttendances))]
        [MapperIgnoreTarget(nameof(PersonalInfo.ClassAttendances))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Classes))]
        [MapperIgnoreTarget(nameof(PersonalInfo.Conventions))]
        [MapperIgnoreTarget(nameof(PersonalInfo.ConventionInvites))]
        [MapperIgnoreTarget(nameof(PersonalInfo.UserRoles))]
        public partial PersonalInfo CreateGainedUserToPersonalInfo(CreateGainedUser source);

        // ===== PersonalInfo -> GainedUser =====

        [MapProperty(nameof(PersonalInfo.Id), nameof(GainedUser.Document))]
        [MapperIgnoreSource(nameof(PersonalInfo.UserName))]
        [MapperIgnoreSource(nameof(PersonalInfo.NormalizedUserName))]
        [MapperIgnoreSource(nameof(PersonalInfo.NormalizedEmail))]
        [MapperIgnoreSource(nameof(PersonalInfo.Email))]
        [MapperIgnoreSource(nameof(PersonalInfo.EmailConfirmed))]
        [MapperIgnoreSource(nameof(PersonalInfo.PasswordHash))]
        [MapperIgnoreSource(nameof(PersonalInfo.SecurityStamp))]
        [MapperIgnoreSource(nameof(PersonalInfo.ConcurrencyStamp))]
        [MapperIgnoreSource(nameof(PersonalInfo.PhoneNumber))]
        [MapperIgnoreSource(nameof(PersonalInfo.PhoneNumberConfirmed))]
        [MapperIgnoreSource(nameof(PersonalInfo.TwoFactorEnabled))]
        [MapperIgnoreSource(nameof(PersonalInfo.LockoutEnd))]
        [MapperIgnoreSource(nameof(PersonalInfo.LockoutEnabled))]
        [MapperIgnoreSource(nameof(PersonalInfo.AccessFailedCount))]
        [MapperIgnoreSource(nameof(PersonalInfo.City))]
        [MapperIgnoreSource(nameof(PersonalInfo.Address))]
        [MapperIgnoreSource(nameof(PersonalInfo.EducationalLevel))]
        [MapperIgnoreSource(nameof(PersonalInfo.Profession))]
        [MapperIgnoreSource(nameof(PersonalInfo.Occupation))]
        [MapperIgnoreSource(nameof(PersonalInfo.MaritalStatus))]
        [MapperIgnoreSource(nameof(PersonalInfo.Birthday))]
        [MapperIgnoreSource(nameof(PersonalInfo.LastAccess))]
        [MapperIgnoreSource(nameof(PersonalInfo.GainedId))]
        [MapperIgnoreSource(nameof(PersonalInfo.GainedRecord))]
        [MapperIgnoreSource(nameof(PersonalInfo.Cell))]
        [MapperIgnoreSource(nameof(PersonalInfo.CellEnrollmentDate))]
        [MapperIgnoreSource(nameof(PersonalInfo.Cells))]
        [MapperIgnoreSource(nameof(PersonalInfo.Gained))]
        [MapperIgnoreSource(nameof(PersonalInfo.MeetingAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.CellAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.ClassAttendances))]
        [MapperIgnoreSource(nameof(PersonalInfo.Classes))]
        [MapperIgnoreSource(nameof(PersonalInfo.Conventions))]
        [MapperIgnoreSource(nameof(PersonalInfo.ConventionInvites))]
        [MapperIgnoreSource(nameof(PersonalInfo.UserRoles))]
        [MapperIgnoreTarget(nameof(GainedUser.Events))]
        [MapperIgnoreTarget(nameof(GainedUser.Petition))]
        [MapperIgnoreTarget(nameof(GainedUser.Photo))]
        public partial GainedUser PersonalInfoToGainedUser(PersonalInfo source);

        // Gained -> GainedUser (flatten Person properties)
        public GainedUser GainedToGainedUser(Gained source)
        {
            var user = PersonalInfoToGainedUser(source.Person);
            user.Events = GainedEventListToGainedEventDtoList(source.Events);
            return user;
        }

        // ===== GainedEvent mappings =====

        [MapProperty(nameof(Domain.GainedEvent.EventId), nameof(Common.Dtos.Gained.GainedEvent.Id))]
        [MapperIgnoreSource(nameof(Domain.GainedEvent.GainedId))]
        [MapperIgnoreSource(nameof(Domain.GainedEvent.Gained))]
        [MapperIgnoreSource(nameof(Domain.GainedEvent.Date))]
        public partial Common.Dtos.Gained.GainedEvent GainedEventToGainedEventDto(Domain.GainedEvent source);
        public partial List<Common.Dtos.Gained.GainedEvent> GainedEventListToGainedEventDtoList(List<Domain.GainedEvent> source);

        // ===== Meeting mappings =====

        [MapProperty(nameof(CreateMeetingDto.MeetingTypes), nameof(Meeting.MeetingType))]
        [MapperIgnoreTarget(nameof(Meeting.Id))]
        [MapperIgnoreTarget(nameof(Meeting.MeetingAttendances))]
        public partial Meeting CreateMeetingDtoToMeeting(CreateMeetingDto source);

        [MapProperty(nameof(Meeting.Id), nameof(MeetingDto.MeetingId))]
        [MapProperty(nameof(Meeting.MeetingType), nameof(MeetingDto.MeetingTypes))]
        [MapperIgnoreSource(nameof(Meeting.MeetingAttendances))]
        public partial MeetingDto MeetingToMeetingDto(Meeting source);

        // ===== CellAttendance mappings =====

        [MapperIgnoreSource(nameof(CellAttendance.CellId))]
        [MapperIgnoreSource(nameof(CellAttendance.Cell))]
        [MapperIgnoreTarget(nameof(CellAttendanceDto.MissingAttendees))]
        public partial CellAttendanceDto CellAttendanceToCellAttendanceDto(CellAttendance source);

        // ===== Location mappings =====

        public partial CityDto CityToCityDto(City source);
        public partial City CityDtoToCity(CityDto source);
        public partial LocalityDto LocalityToLocalityDto(Locality source);
        public partial Locality LocalityDtoToLocality(LocalityDto source);

        // ===== DiscipleshipNote mappings =====

        [MapProperty(nameof(DiscipleshipNote.Id), nameof(DiscipleshipNoteDto.NoteId))]
        [MapProperty(nameof(DiscipleshipNote.Status), nameof(DiscipleshipNoteDto.NoteStatus))]
        [MapperIgnoreSource(nameof(DiscipleshipNote.Disciple))]
        [MapperIgnoreSource(nameof(DiscipleshipNote.Leader))]
        [MapperIgnoreSource(nameof(DiscipleshipNote.Categories))]
        [MapperIgnoreSource(nameof(DiscipleshipNote.Entries))]
        [MapperIgnoreTarget(nameof(DiscipleshipNoteDto.Categories))]
        [MapperIgnoreTarget(nameof(DiscipleshipNoteDto.Entries))]
        private partial DiscipleshipNoteDto DiscipleshipNoteToDto(DiscipleshipNote source);

        public DiscipleshipNoteDto DiscipleshipNoteToDiscipleshipNoteDto(DiscipleshipNote source)
        {
            var dto = DiscipleshipNoteToDto(source);
            dto.Categories = JsonSerializer.Deserialize<List<string>>(source.Categories) ?? [];
            dto.Entries = DiscipleshipNoteEntryListToDtoList(source.Entries);
            return dto;
        }

        public IList<DiscipleshipNoteDto> DiscipleshipNoteListToDiscipleshipNoteDtoList(IEnumerable<DiscipleshipNote> source)
            => source.Select(DiscipleshipNoteToDiscipleshipNoteDto).ToList();

        // ===== DiscipleshipNoteEntry mappings =====

        [MapperIgnoreSource(nameof(DiscipleshipNoteEntry.Note))]
        [MapperIgnoreSource(nameof(DiscipleshipNoteEntry.Author))]
        public partial DiscipleshipNoteEntryDto DiscipleshipNoteEntryToDto(DiscipleshipNoteEntry source);

        public partial IList<DiscipleshipNoteEntryDto> DiscipleshipNoteEntryListToDtoList(IEnumerable<DiscipleshipNoteEntry> source);

        // ===== Collection mappings =====

        public partial IList<PartialUserInfoDto> PersonalInfoListToPartialUserInfoDtoList(IEnumerable<PersonalInfo> source);
        public partial IList<GainedUser> GainedListToGainedUserList(IList<Gained> source);
        public partial IEnumerable<CellDto> CellListToCellDtoList(IEnumerable<Cell> source);
        public partial IEnumerable<SchoolDto> SchoolListToSchoolDtoList(IEnumerable<School> source);
        public partial IList<MeetingDto> MeetingListToMeetingDtoList(IEnumerable<Meeting> source);
        public partial IList<CityDto> CityListToCityDtoList(IEnumerable<City> source);
        public partial List<PartialUserInfoDto> PersonalInfoCollectionToPartialUserInfoDtoListConcrete(ICollection<PersonalInfo> source);
        public partial IList<PartialUserInfoDto> PersonalInfoCollectionToPartialUserInfoDtoList(ICollection<PersonalInfo> source);
    }
}
