using EgyptianRecipes.Models;
using EgyptianRecipes.ViewModels;

namespace EgyptianRecipes.Core.Mappers
{
    public class BranchesProfile : AutoMapper.Profile
    {
        public BranchesProfile()
        {
            CreateMap<Branch, BranchViewModel>();
            CreateMap<BranchViewModel, Branch>();
        }
    }
}
