using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class Responses
    {
        public int Id { get; set; }
        // Optional responses to help users filter other users
        public int Religion { get; set; }
        public int Politics { get; set; }
        public int Sports { get; set; }
        public int Diet { get; set; }
        public int Entertainment { get; set; }
        public int HonestySpectrum { get; set; }
    }
}
