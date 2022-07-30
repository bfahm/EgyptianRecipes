using EgyptianRecipes.Models;
using EgyptianRecipes.Persistence.DbContexts;
using EgyptianRecipes.Persistence.Repositories.Abstract;

namespace EgyptianRecipes.Persistence.Repositories
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }
    }
}
