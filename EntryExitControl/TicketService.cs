using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.VehicleControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.EntryExitControl
{
    public class TicketService
    {
        public Ticket CreateTicket(Vehicle vehicle, ParkingSpot allocatedSpot,int userId,string userName)
        {
            return new Ticket(new Random().Next(1, 10000), vehicle, allocatedSpot, DateTime.Now,userId,userName);
        }

    }
}
