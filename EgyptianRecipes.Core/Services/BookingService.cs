using AutoMapper;
using EgyptianRecipes.Models;
using EgyptianRecipes.Persistence.Repositories.Abstract;
using EgyptianRecipes.ViewModels;
using System.Threading.Tasks;

namespace EgyptianRecipes.Core.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task AddBooking(long branchId, BookingRequestViewModel request)
        {
            var booking = _mapper.Map<Booking>(request);
            booking.BranchId = branchId;

            await _bookingRepository.AddAsync(booking);
        }
    }
}
