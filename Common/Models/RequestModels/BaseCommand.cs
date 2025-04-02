using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels
{
    public abstract class BaseCommand:IRequest<Guid>
    {
    }
}
