using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.UserControl;
using ParkingLotSource.VehicleControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.EntryExitControl
{
    public class EntryGate
    {
        private int ID;
        private string Name;
        private VehicleFactory VehiFactory;
        private ParkingSpotManager parkingSpotManager;
        private TicketService ticketService;
        private FareRateManger fareRateManager;
       
        public EntryGate(int id, string name )
        {
           
            this.ID = id;
            this.Name = name;
            
        }
        public void Configure(TicketService ticketservice, VehicleFactory vehicleFactory, ParkingSpotManager parkingSpotManager,FareRateManger fareRateManger)
        {
            this.VehiFactory = vehicleFactory;
            this.ticketService = ticketservice;
            this.parkingSpotManager = parkingSpotManager;


        }
        private Vehicle createVehicleObjbyType(string LicenseType, string VehicleType)
        {
            return VehiFactory.CreateVehicle(LicenseType, VehicleType);
        }

        private List<ParkingSpot> FindAvailSpot(string VehicleType, bool hasHandicapPermit)
        {
           return parkingSpotManager.GetAvailSpotbyVehicleType(VehicleType, hasHandicapPermit);
        }
        private ParkingSpot AllocateSpot(List<ParkingSpot> availableSpots,Vehicle vehicle, bool hasHandicapPermit)
        {
            if (availableSpots == null || availableSpots.Count == 0)
            {
                throw new InvalidOperationException("No available parking spots.");
            }
            return parkingSpotManager.AllocateSpot(availableSpots[0].ID, vehicle, hasHandicapPermit);
        }
        public Ticket IssueTicket(string LicenseType, string VehicleType,bool hasHandicapPermit, int userId, string userName)
        {
            Vehicle vehicle = createVehicleObjbyType(LicenseType, VehicleType);

           List<ParkingSpot> lstSpot = FindAvailSpot(VehicleType, hasHandicapPermit);

            // Allocate the available spot
            ParkingSpot allocatedSpot = AllocateSpot(lstSpot, vehicle, hasHandicapPermit);

            // Create ticket
            Ticket ticket = CreteTicketForAllocatedVehicle(vehicle, allocatedSpot,userId,userName);
            return ticket;

        }
        private Ticket CreteTicketForAllocatedVehicle(Vehicle vehicle, ParkingSpot allocatedSpot,int userId,string userName)
        {
            return ticketService.CreateTicket(vehicle, allocatedSpot,userId, userName);
        }
        public double GetRate(string spotType)
        {
            return fareRateManager.GetRate(spotType); 
        }
    }
}
