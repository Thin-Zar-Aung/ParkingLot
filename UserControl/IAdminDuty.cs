using ParkingLotSource.EntryExitControl;
using ParkingLotSource.FareControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.UserControl
{
    public interface IAdminDuty
    {
        public void AddParkingSpot(int spotId, string spotType, bool isHandicap = false);
        public void RemoveParkingSpot(int spotId);
        public void SetRate(string spotType, double rate);
        public double ViewRate(string spotType);
        public void ManagePaymentFailure(Ticket ticket, string paymentType, double fare, double cashTendered, string nameOnCard);

    }
}
