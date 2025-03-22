using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IWriteRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        Task<bool> AddAsync(Entity entity);
        Task<bool> AddRangeAsync(List<Entity> model);
        bool Remove(Entity model);
        Task<bool> RemoveAsync(Guid id);
        bool Update(Entity model);
        Task<int> SaveChangesAsync();
    }
}
