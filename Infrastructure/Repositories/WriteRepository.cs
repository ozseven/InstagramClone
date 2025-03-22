using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class WriteRepository<Entity> : Repository<Entity>, IWriteRepository<Entity> where Entity : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public WriteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Entity entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<Entity> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Remove(Entity model)
        {
            var entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var result = await Table.SingleOrDefaultAsync(x => x.Id == id);
            return Remove(result);
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public bool Update(Entity model)
        {
            var entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
