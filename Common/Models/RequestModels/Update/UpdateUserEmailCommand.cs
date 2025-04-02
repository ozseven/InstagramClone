﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.RequestModels.Update
{
    public class UpdateUserEmailCommand:BaseUpdateCommand
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }

    }
}
