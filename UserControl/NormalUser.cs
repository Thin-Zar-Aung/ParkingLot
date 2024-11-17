using ParkingLotSource.EntryExitControl;
using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.PaymentControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkingLotSource.UserControl
{
    public class NormalUser : User
    {
        public override void DisplayParkingLotInfo(DisplayBoard display)
        {
            display.DisplayParkingLotStatus();
            display.DisplayFareRates();

        }

         public NormalUser(string name="Guest")
        {
            this.id = new Random().Next(0, 1000);
            this.name = name;

        }
        public Ticket GetTicket(string license, string vehicleType, bool hasHandicapPermit, EntryGate entryGate,int userId,string userName)
        {
            return entryGate.IssueTicket(license, vehicleType, hasHandicapPermit,userId,userName);
        }

        public double GetParkingFee(Ticket ticket, ExitGate exitGate)
        {
           return exitGate.GetParkingFare(ticket);
        }
        public string MakePayment(Ticket ticket, PaymentService paymentService)
        {
           return paymentService.ProcessPayment(15.0, ticket, "Cash", 20.0);
        }
        public void ExitParkingLot(Ticket ticket, ExitGate exitGate)
        {
            exitGate.FinalizeExit(ticket);
        }

        public void ViewTicketDetails(Ticket ticket, DisplayBoard display)
        {
            Console.WriteLine($"User ID: {ticket.getUserID()}");
            Console.WriteLine($"User Name: {ticket.getUserName()}");
            Console.WriteLine($"Ticket ID: {ticket.getID()}");           
            Console.WriteLine($"Entry Time: {ticket.getEntryTime()}");
            ParkingSpot parkingSpot = ticket.getParkingSpot();
            Console.WriteLine($"Allocated Spot: {parkingSpot.ID}");
            Console.WriteLine($"Spot Type: {parkingSpot.SpotType}");
            Console.WriteLine("Handicapped Spot:" + (parkingSpot.IsHandicapped? "Yes":"No"));
            Console.WriteLine($"Hourly Fees: {display.DisplayRateForSpotType(parkingSpot.SpotType)}");
        }

     
    }
}