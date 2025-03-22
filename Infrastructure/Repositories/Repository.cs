using Application.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity :BaseEntity 
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<Entity> Table => _context.Set<Entity>();

    }
}
