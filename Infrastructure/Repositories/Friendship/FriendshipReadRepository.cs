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
    public class FriendshipReadRepository : ReadRepository<Friendship>, IFriendshipReadRepository
    {
        public FriendshipReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
