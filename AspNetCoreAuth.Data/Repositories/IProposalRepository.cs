using AspNetCoreAuth.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AspNetCoreAuth.Data.Repositories
{
    public interface IProposalRepository
    {
        Task<int> Add(ProposalModel model);
        Task<ProposalModel> Approve(int proposalId);
        Task<List<ProposalModel>> GetAllForConference(int conferenceId);
    }
}