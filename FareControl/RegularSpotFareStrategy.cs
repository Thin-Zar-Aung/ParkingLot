using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public class RegularSpotFareStrategy : IFareStrategy
    {
        private readonly FareRateManger _fareSettings;

        public RegularSpotFareStrategy(FareRateManger fareSettings)
        {
            _fareSettings = fareSettings;
        }

        public double CalculateParkingFess(Ticket ticket)
        {

            double hourlyRate = _fareSettings.GetRate("Regular");
            TimeSpan timeSpent = ticket.getExitTime() - ticket.getEntryTime();
            int hoursParked = (int)Math.Ceiling(timeSpent.TotalHours);
            return hourlyRate * hoursParked;
        }
    }
}