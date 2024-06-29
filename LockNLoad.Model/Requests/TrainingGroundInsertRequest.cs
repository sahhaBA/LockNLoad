﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Model.Requests
{
    public class TrainingGroundInsertRequest
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string LocationImageUrl { get; set; } = null!;
        public string? Description { get; set; }
    }
}