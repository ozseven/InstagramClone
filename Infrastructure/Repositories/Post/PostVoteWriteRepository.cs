using Application.Interfaces.Repositories;
using Domain.Vote;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostVoteWriteRepository : WriteRepository<PostVote>, IPostVoteWriteRepository
    {
        public PostVoteWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
