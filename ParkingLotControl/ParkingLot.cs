using ParkingLotSource.EntryExitControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.VehicleControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.ParkingLotControl
{
    public class ParkingLot
    {
        private int id;
        private string name;
        private string address;
        private ParkingSpotManager parkingSpotManager;
        private GateManager gateManager;
       
       
        public ParkingLot(string name,int id, string address, ParkingSpotManager parkingSpotManager,GateManager gateManager)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.parkingSpotManager = parkingSpotManager;
            this.gateManager = gateManager;


        }
    
        public List<ParkingSpot> GetAvailableSpots()
        {
            return parkingSpotManager.GetAvailableSpots();
        }
         public List<ParkingSpot> GetAllSpots()
       {
            return parkingSpotManager.GetAllSpots();
       }
        public void PrintParkingLot()
        {
            Console.WriteLine("ParkingLot Name: " + name);
            Console.WriteLine("Address: " + address);
            Console.WriteLine($"Total Gates: {gateManager.GetTotalGates()}");
            Console.WriteLine($"Entry Gates: {gateManager.GetEntryGateCount()}");
            Console.WriteLine($"Exit Gates: {gateManager.GetExitGateCount()}");
        }
       

    }
}
