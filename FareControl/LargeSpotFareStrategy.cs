using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public class LargeSpotFareStrategy : IFareStrategy
    {
        private readonly FareRateManger _fareSettings;

        public LargeSpotFareStrategy(FareRateManger fareSettings)
        {
            _fareSettings = fareSettings;
        }

        public double CalculateParkingFess(Ticket ticket)
        {
            
            double hourlyRate = _fareSettings.GetRate("Large");
            int hoursParked = (int)Math.Ceiling((ticket.getExitTime() - ticket.getEntryTime()).TotalHours);
            return hourlyRate * hoursParked;
        }
    }
}