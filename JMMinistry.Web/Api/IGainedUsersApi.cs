using JMMinistry.Common;
using JMMinistry.Common.Dtos.Gained;

namespace JMMinistry.Web.Api
{
    public interface IGainedUsersApi
    {

        Task<Response<GainedUser>?> RegisterGainedPerson(CreateGainedUser createGained);
        Task<Response<IList<GainedUser>>?> GetGainedUsers();
    }
}
