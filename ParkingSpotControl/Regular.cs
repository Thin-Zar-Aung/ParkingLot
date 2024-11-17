using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.ParkingSpotControl
{
    public class Regular : ParkingSpot
    {
        public Regular(int iD, string spotType, bool isHandicapped) : base(iD, spotType, isHandicapped)
        {
        }
    }
}
