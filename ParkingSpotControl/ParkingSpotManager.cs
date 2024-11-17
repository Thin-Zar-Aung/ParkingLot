using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.VehicleControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.ParkingSpotControl
{
    public class ParkingSpotManager
    {
        private List<ParkingSpot> listParkingSpot;

        public ParkingSpotManager()
        {
            this.listParkingSpot = new List<ParkingSpot>();
        }

        public void AddSpot(ParkingSpot parkingSpot)
        {            
            listParkingSpot.Add(parkingSpot);
        }
        public void RemoveSpot(int spotId)
        {
            var spot = listParkingSpot.FirstOrDefault(s => s.ID == spotId);
            if (spot != null)
            {
                listParkingSpot.Remove(spot);
            }
        }

        public ParkingSpot AllocateSpot(int spotID, Vehicle vehicle,bool HashandicapPermit)
        {
            ParkingSpot allocatedspot = listParkingSpot.Where(s => s.ID == spotID && s.IsAvailable && s.IsHandicapped == HashandicapPermit).First();
            if (allocatedspot != null)
            {
                allocatedspot.IsAvailable = false;
                allocatedspot.OccupyVehicle = vehicle;
                return allocatedspot;

            }
            
            return null;
          
        }

        public void DeAllocateSpot(int spotId)
        {
            ParkingSpot spot = listParkingSpot.Find(s => s.ID == spotId && !s.IsAvailable);
            if (spot != null)
            { spot.OccupyVehicle = null;
                spot.IsAvailable = false;
            }
            else
            {
                Console.WriteLine("Cannot find the spot to deallocate.");
            }
        }
        public List<ParkingSpot> GetAvailableSpots()
        {
            return listParkingSpot.Where(s => s.IsAvailable).ToList();
        }
        public List<ParkingSpot> GetAllSpots()
        {
            return listParkingSpot;
        }

        public List<ParkingSpot> GetOccupiedSpots()
        {
            return listParkingSpot.Where(s=>!s.IsAvailable).ToList();
        }
        public List<ParkingSpot> GetAvailSpotbyVehicleType(string type, bool Ishandicap)
        {
            Console.WriteLine("Check Available spot by vehicle Type");
            string SpotType;
            switch (type)
            {
                
                case "Truck":
                    SpotType = "Large";
                    break;
                case "Van":
                    SpotType = "Large";
                    break;
                case "Car":
                    SpotType = "Regular";
                    break;
                case "Motorcycle":
                    SpotType = "Small";
                    break;
                default:
                    Console.WriteLine("Invalid Vehicle Type");
                    throw new ArgumentException("Invalid vehicle type");

            }
            return listParkingSpot.Where(s => s.SpotType == SpotType && s.IsAvailable && s.IsHandicapped == Ishandicap).ToList();

        }
        
    }
}
