using AutoMapper;
using EgyptianRecipes.Models;
using EgyptianRecipes.Persistence.Repositories.Abstract;
using EgyptianRecipes.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EgyptianRecipes.Core.Services
{
    public class BranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IMapper mapper, IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
        }

        public async Task<List<BranchViewModel>> GetBranches()
        {
            var branches = await _branchRepository.GetAllAsync();
            return _mapper.Map<List<BranchViewModel>>(branches);
        }

        public async Task<BranchViewModel> GetBranchById(long? id)
        {
            if (id == null)
                throw new NotFoundException();

            var branch = await _branchRepository.GetByIdAsync((long)id);

            if (branch == null)
                throw new NotFoundException();

            return _mapper.Map<BranchViewModel>(branch);
        }

        public async Task<BranchViewModel> AddBranch(BranchViewModel request)
        {
            var branch = _mapper.Map<Branch>(request);
            branch = await _branchRepository.AddAsync(branch);

            return _mapper.Map<BranchViewModel>(branch);
        }

        public async Task<BranchViewModel> UpdateBranch(BranchViewModel request)
        {
            var existingBranch = await _branchRepository.GetByIdAsync(request.Id);
            if (existingBranch == null)
                throw new NotFoundException();

            var updatedBranch = _mapper.Map<BranchViewModel, Branch>(request, existingBranch);
            updatedBranch = await _branchRepository.UpdateAsync(updatedBranch);

            return _mapper.Map<BranchViewModel>(updatedBranch);
        }

        public async Task DeleteBranch(long id)
        {
            var existingBranch = await _branchRepository.GetByIdAsync(id);
            if (existingBranch == null)
                throw new NotFoundException();

            await _branchRepository.RemoveAsync(existingBranch);
        }
    }
}
