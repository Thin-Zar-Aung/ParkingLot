using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.PaymentControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.EntryExitControl
{
    public class ExitGate
    {
        private int ID;
        private string name;
        private ParkingSpotManager parkingspotManager;
        private FareCalculatorFactory fareCalculatorFactory;
        private PaymentService paymentService;
        private FareRateManger fareRateManger;
        

        public ExitGate(int id,string name )
        {
            this.ID = id;
            this.name = name;
            
           
        }
        public void configure(ParkingSpotManager parkingspotManager, FareCalculatorFactory fareCalculatorFactory, PaymentService paymentService,FareRateManger fareRateManager)
        {
            this.parkingspotManager = parkingspotManager;
            this.fareCalculatorFactory = fareCalculatorFactory;
            this.paymentService = paymentService;
            this.fareRateManger= fareRateManager;
        }

        public double GetParkingFare(Ticket ticket)
        {
            ticket.setExitTime(DateTime.Now);
            FareCalculator fareCalculator = fareCalculatorFactory.CreateFareCalculator(ticket.getParkingSpot(), fareRateManger);
            return fareCalculator.CalculateParkingFee(ticket);
        }

       

        public string ProcessPayment(double parkingFee, Ticket ticket, string paymentType, double cashTendered, string nameOnCard = "")
        {
            return paymentService.ProcessPayment(parkingFee, ticket, paymentType, cashTendered, nameOnCard);             
        }

        public void FinalizeExit(Ticket ticket)
        {
            if (ticket != null && ticket.getParkingSpot() != null) {

                parkingspotManager.DeAllocateSpot(ticket.getParkingSpot().ID);
               
            }
        }
    }
}

