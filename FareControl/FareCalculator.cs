using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public class FareCalculator
    {
        private IFareStrategy _strategy;
        public FareCalculator(IFareStrategy strategy)
        {
            _strategy = strategy;
        }

        public double CalculateParkingFee(Ticket ticket)
        {
            return _strategy.CalculateParkingFess(ticket);
        }
    }

}