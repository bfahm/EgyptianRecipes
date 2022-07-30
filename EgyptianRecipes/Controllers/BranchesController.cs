using EgyptianRecipes.Core.Services;
using EgyptianRecipes.Models;
using EgyptianRecipes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EgyptianRecipes.Controllers
{
    [Authorize]
    public class BranchesController : Controller
    {
        private readonly BranchService _branchService;

        public BranchesController(BranchService branchService)
        {
            _branchService = branchService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        [HttpGet("[controller]")]
        [HttpGet("[controller]/[action]")]
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var branches = await _branchService.GetBranches();
            return View(branches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ManagerName,OpeningHour,ClosingHour")] BranchViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _branchService.AddBranch(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long? id)
        {
            try
            {
                var branch = await _branchService.GetBranchById(id);
                return View(branch);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,ManagerName,OpeningHour,ClosingHour")] BranchViewModel request)
        {
            if (id != request.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(request);

            try
            {
                await _branchService.UpdateBranch(request);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] long id)
        {
            try
            {
                await _branchService.DeleteBranch(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
