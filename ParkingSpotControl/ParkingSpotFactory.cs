using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.ParkingSpotControl
{
    public class ParkingSpotFactory
    {
        public ParkingSpot CreateNewParkingSpot(int ID,String SpotType,bool isHandicapped)
        {
            switch (SpotType)
            {
                case "Small":
                    return new Small(ID, SpotType,isHandicapped);
                case "Large":
                    return new Large(ID, SpotType, isHandicapped);
                case "Regular":
                    return new Regular(ID, SpotType, isHandicapped);
                default:
                    throw new Exception("Wrong SpotType");
            }
        }
    }
}
