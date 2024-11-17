using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public class SmallSpotFareStrategy : IFareStrategy
    {
        private FareRateManger _settings;
      public  SmallSpotFareStrategy(FareRateManger settings)
        {
            this._settings = settings;
        }
        public double CalculateParkingFess(Ticket ticket)
        {
            double hourlyFees = _settings.GetRate("Small");
            int hourParked = (int)Math.Ceiling((ticket.getExitTime() - ticket.getEntryTime()).TotalHours);
            return hourParked * hourlyFees;
        }

    }
}
