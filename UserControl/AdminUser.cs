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
    public class AdminUser : User, IAdminDuty
    {
        private ParkingSpotManager parkingSpotManager;
        private FareRateManger fareRateManger;
        private PaymentService paymentService;
        private FareCalculatorFactory fareCalculatorFactory;

        public AdminUser(int id, string name)
        {
            this.id = id;
            this.name = name;
            
        }
        public void Configure(ParkingSpotManager parkingSpotManager, FareRateManger fareRateManager, PaymentService paymentService, FareCalculatorFactory fareCalculatorFactory)
        {
            this.parkingSpotManager = parkingSpotManager;
            this.fareRateManger = fareRateManager;
            this.paymentService = paymentService;
            this.fareCalculatorFactory = fareCalculatorFactory;

        }
        public void AddParkingSpot(int spotId, string spotType, bool isHandicap = false)
        {
            parkingSpotManager.AddSpot(new ParkingSpot(spotId, spotType, isHandicap));
        }

        public void RemoveParkingSpot(int spotId)
        {
            parkingSpotManager.RemoveSpot(spotId);
        }


        public override void DisplayParkingLotInfo(DisplayBoard display)
        {
            display.DisplayParkingLotStatus();

            parkingSpotManager.GetOccupiedSpots();


        }

      
        public  void ManagePaymentFailure(Ticket ticket, string paymentType, double fare,double cashTendered, string nameOnCard = "")
        {
            Console.WriteLine("Payment process by admin");
            ParkingSpot parkingSpot = ticket.getParkingSpot();
            // Use FareCalculatorFactory to create the appropriate FareCalculator
            FareCalculator fareCalculator = fareCalculatorFactory.CreateFareCalculator(parkingSpot, fareRateManger);
            paymentService.ProcessPayment(fare,ticket,paymentType,cashTendered,nameOnCard);
        }

        public void SetRate(string spotType, double rate)
        {
            fareRateManger.setRate(spotType, rate);
        }
        public  double ViewRate(string spotType)
        {
            return fareRateManger.GetRate(spotType);
        }



    }
}
