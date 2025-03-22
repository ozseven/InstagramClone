using Application.Interfaces.Repositories;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostReadRepository : ReadRepository<Domain.Post>, IPostReadRepository
    {
        public PostReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
