using Common.Models.RequestModels.Create.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Create
{
    public class CreateUserCommand:BaseCreateCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhotoLink { get; set; }
        public string About { get; set; }
        public int Gender { get; set; }
        public bool IsPrivate { get; set; }
    }
}
