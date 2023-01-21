using AspNetCoreAuth.Data.Models;
using AspNetCoreAuth.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAuth.Web.Controllers
{
    [Authorize]
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
            return View(await _conferenceRepository.GetAll());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model) 
        {
            if (ModelState.IsValid)
            {
                await _conferenceRepository.Add(model);
            }
        return RedirectToAction(nameof(Index));
        }
    }
}
