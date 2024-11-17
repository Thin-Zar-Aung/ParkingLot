using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotSource.VehicleControl;

namespace ParkingLotSource.ParkingSpotControl
{
    public  class ParkingSpot
    {
        public int ID;
        public string SpotType;
        public bool IsAvailable;
        public bool IsHandicapped;
        public Vehicle OccupyVehicle;
        public ParkingSpot(int iD, string spotType, bool isHandicapped)
        {
            ID = iD;
            SpotType = spotType;
            IsAvailable = true;
            OccupyVehicle = null;
            IsHandicapped = isHandicapped;
        }
        // Basic view for normal users
        public override string ToString()
        {
            return $"Spot ID: {ID}, Type: {SpotType}, Handicapped: {IsHandicapped}, Available: {IsAvailable}";
        }

        // Detailed view for admin users
        public string ToAdminString()
        {
            return $"Spot ID: {ID}, Type: {SpotType}, Handicapped: {IsHandicapped}, Available: {IsAvailable}, License: {(OccupyVehicle != null ? OccupyVehicle.getLicense() : "None")}";
        }

    }
}
