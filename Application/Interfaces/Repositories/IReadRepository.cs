using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IReadRepository<Entity>:IRepository<Entity> where Entity : BaseEntity , new()
    {
        IQueryable<Entity> GetAll();
        IQueryable<Entity> GetWhere(Expression<Func<Entity, bool>> method);
        Task<Entity> GetSingleAsync(Expression<Func<Entity, bool>> method, params Expression<Func<Entity, object>>[] includes);
        Task<Entity> GetByIdAsync(Guid id);
    }
}
