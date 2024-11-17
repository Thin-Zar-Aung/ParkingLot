using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.ParkingSpotControl;
namespace ParkingLotSource.UserControl
{
    public abstract class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool HasHadicapPermit { get; set; }
        public abstract void DisplayParkingLotInfo(DisplayBoard display);
        public void DisplayFareRates(DisplayBoard display)
        {
            display.DisplayFareRates();
        }    



    }
}
