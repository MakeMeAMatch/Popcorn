using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Models
{
    public class MenuEnum
    {
        //adding a list of qualitites to search by on the browse controller
        public enum ParentLottery
        {
            NumberOfChildren = 1, CityState, PlaySpots, KidsAgeRange, Religion, Politics, Sports, Diet, Entertainment, HonestySpectrum
        }

        public ParentLottery Parents
        {
            get; set;
        }
    }
}
