using AspNetCoreAuth.Data.Models;
using AspNetCoreAuth.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAuth.Web.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IProposalRepository _proposalRepository;

        public ProposalController(IConferenceRepository conferenceRepo, IProposalRepository proposalRepo)
        {
            _conferenceRepository = conferenceRepo;
            _proposalRepository = proposalRepo;
        }
        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await _conferenceRepository.GetById(conferenceId);
            ViewBag.Title = $"Speaker - Proposals for conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(await _proposalRepository.GetAllForConference(conferenceId));
        }
        public IActionResult AddProposal(int conferenceId)
        {
            ViewBag.Title = "Speaker - Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }
        [HttpPost]
        public async Task<IActionResult> AddProposal(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                await _proposalRepository.Add(proposal);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalRepository.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}
