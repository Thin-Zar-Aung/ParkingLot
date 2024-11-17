using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.VehicleControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.EntryExitControl
{
    public class Ticket
    {
        private int Id;
        private int userId;
        private string userName;
        private Vehicle vehicle;
        private DateTime EntryTime;
        private DateTime ExitTime;
        private ParkingSpot ParkSpot;
        
        public Ticket(int id, Vehicle vehicle, ParkingSpot parkingSpot, DateTime entryTime, int userId, string userName)
        {
            this.vehicle = vehicle;
            this.EntryTime = entryTime;
            this.ParkSpot = parkingSpot;
            this.Id = id;
            this.userId = userId;
            this.userName = userName;
        }
        public void setExitTime(DateTime ExitTime) {
            this.ExitTime = ExitTime;
        }
        public DateTime getEntryTime()
        {
            return this.EntryTime;
        }
        public DateTime getExitTime()
        {
            return this.ExitTime;
        }
        public ParkingSpot getParkingSpot()
        {
            return this.ParkSpot;
        }
        public int getID()
        {
            return this.Id;
        }
        public int getUserID()
        {
            return this.userId;
        }
        public string getUserName()
        {
            return this.userName;
        }
     
    }
}
