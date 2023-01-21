using System.Threading.Tasks;
using AspNetCoreAuth.Data.Entities;
using AspNetCoreAuth.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAuth.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly ConfDbContext dbContext;

        public AttendeeRepository(ConfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> Add(AttendeeModel attendee)
        {
            var entity = Attendee.FromModel(attendee);
            dbContext.Attendees.Add(entity);
            return dbContext.SaveChangesAsync();
        }

        public Task<int> GetAttendeesTotal(int conferenceId)
        {
            return dbContext.Attendees.CountAsync(a => a.ConferenceId == conferenceId);
        }
    }
}
