using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class Users
    {
        public int Id { get; set; }
        // Each User with their associated set of optional responses
        public int UserId { get; set; }
        public int ResponsesId { get; set; }
    }
}
