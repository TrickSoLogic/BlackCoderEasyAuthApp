using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAuth.Data.Entities;
using AspNetCoreAuth.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAuth.Data.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly ConfDbContext dbContext;

        public ProposalRepository(ConfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<ProposalModel>> GetAllForConference(int conferenceId)
        {
            return dbContext.Proposals.Where(p => p.ConferenceId == conferenceId).Select(p => p.ToModel()).ToListAsync();
        }


        public Task<int> Add(ProposalModel model)
        {
            var entity = Proposal.FromModel(model);
            dbContext.Proposals.Add(entity);
            return dbContext.SaveChangesAsync();
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            var proposal = await dbContext.Proposals.FirstAsync(p => p.Id == proposalId);
            proposal.Approved = true;
            await dbContext.SaveChangesAsync();
            return proposal.ToModel();
        }
    }
}
