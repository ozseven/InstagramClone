using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ReadRepository<Entity> :Repository<Entity>, IReadRepository<Entity> where Entity :BaseEntity
    {
        public ReadRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Entity> GetAll()
            => Table.Where(i => i.IsDeleted == false);

        public async Task<Entity> GetByIdAsync(Guid id)
            => await Table.FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);

        public async Task<Entity> GetSingleAsync(Expression<Func<Entity, bool>> method,
                                                  params Expression<Func<Entity, object>>[] includes)
        {
            IQueryable<Entity> query = Table.Where(method).Where(i => !i.IsDeleted);
            foreach (var include in includes)
                query = query.Include(include);
            return await query.SingleOrDefaultAsync();
        }
        public IQueryable<Entity> GetWhere(Expression<Func<Entity, bool>> method)
            => Table.Where(i => !i.IsDeleted).Where(method);
    }
}
