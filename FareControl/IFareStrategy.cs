using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public interface IFareStrategy
    {
        public double CalculateParkingFess(Ticket ticket);
    }
}
