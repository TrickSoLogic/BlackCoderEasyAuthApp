using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreAuth.Data.Models;


namespace AspNetCoreAuth.Data.Repositories
{
    public interface IConferenceRepository
    {
        Task<int> Add(ConferenceModel model);
        Task<List<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
    }
}