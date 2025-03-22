using Application.Interfaces.Repositories;
using Domain;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FriendshipWriteRepository : WriteRepository<Friendship>, IFriendshipWriteRepository
    {
        public FriendshipWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
