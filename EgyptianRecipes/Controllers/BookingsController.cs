using EgyptianRecipes.Core.Services;
using EgyptianRecipes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EgyptianRecipes.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BookingService _bookingService;

        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] long id, [Bind("CustomerName,CustomerPhoneNumber,CustomerEmail")] BookingRequestViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _bookingService.AddBooking(id, request);
            return RedirectToAction(nameof(BranchesController.Index), "Branches", null);
        }
    }
}
