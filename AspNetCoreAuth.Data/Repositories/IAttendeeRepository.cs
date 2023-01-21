using System.Threading.Tasks;
using AspNetCoreAuth.Data.Models;


namespace AspNetCoreAuth.Data.Repositories
{
    public interface IAttendeeRepository
    {
        Task<int> Add(AttendeeModel attendee);
        Task<int> GetAttendeesTotal(int conferenceId);
    }
}