using Application.Interfaces.Repositories;
using Common.Infrastructure.Exceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.ExistsDatabase
{
    public class ExistsDatabaseQuery<Entity> 
        where Entity : BaseEntity,new()
    {
        public static async Task<bool> IsExistingAsync(IReadRepository<Entity> _readRepository, Expression<Func<Entity, bool>> method)
        {
            var IsExisting = await _readRepository.GetSingleAsync(method);
            if (IsExisting != null)
            {
                return true;
            }
            return false;
        }
    }
}
