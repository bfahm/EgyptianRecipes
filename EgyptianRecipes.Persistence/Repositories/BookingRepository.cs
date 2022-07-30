using EgyptianRecipes.Models;
using EgyptianRecipes.Persistence.DbContexts;
using EgyptianRecipes.Persistence.Repositories.Abstract;

namespace EgyptianRecipes.Persistence.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
