﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class Matches
    {
        public int Id { get; set; }
        // User that selected another user
        public string UserMatchingId { get; set; }
        // User that was selected
        public string UserMatchedId { get; set; }
    }
}
