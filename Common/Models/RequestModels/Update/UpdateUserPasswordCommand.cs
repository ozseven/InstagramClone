﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Update
{
    public class UpdateUserPasswordCommand:BaseUpdateCommand
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
