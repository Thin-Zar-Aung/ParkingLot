using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.ParkingSpotControl
{
    public class Small : ParkingSpot
    {
        public Small(int iD, string spotType, bool isHandicapped) : base(iD, spotType, isHandicapped)
        {
        }
    }
}
