using EgyptianRecipes.Persistence.DbContexts;
using EgyptianRecipes.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EgyptianRecipes.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T item)
        {
            await context.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public Task<List<T>> GetAllAsync()
        {
            return context.Set<T>().AsNoTracking().ToListAsync();
        }

        public ValueTask<T> GetByIdAsync(long Id)
        {
            return context.Set<T>().FindAsync(Id);
        }

        public Task RemoveAsync(T item)
        {
            context.Set<T>().Remove(item);
            return context.SaveChangesAsync();
        }



        public async Task<T> UpdateAsync(T item)
        {
            context.Set<T>().Update(item);
            await context.SaveChangesAsync();
            return item;
        }
    }
}
