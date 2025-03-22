using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        DbSet<Entity> Table {  get; }
    }
}
