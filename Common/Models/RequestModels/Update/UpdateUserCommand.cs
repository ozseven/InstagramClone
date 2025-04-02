using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Update
{
    public class UpdateUserCommand:BaseUpdateCommand
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhotoLink { get; set; }
        public Gender Gender { get; set; }
        public bool IsPrivate { get; set; }
        public string About { get; set; }
    }
}
