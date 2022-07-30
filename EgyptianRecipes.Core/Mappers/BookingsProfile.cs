using EgyptianRecipes.Models;
using EgyptianRecipes.ViewModels;

namespace EgyptianRecipes.Core.Mappers
{
    public class BookingsProfile : AutoMapper.Profile
    {
        public BookingsProfile()
        {
            CreateMap<BookingRequestViewModel, Booking>();
            CreateMap<Booking, BookingRequestViewModel>();
        }
    }
}
