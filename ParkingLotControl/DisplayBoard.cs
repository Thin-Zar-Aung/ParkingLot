using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingSpotControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.ParkingLotControl
{
    public class DisplayBoard
    {
        private ParkingLot parkingLot;
        private FareRateManger fareRateManager;
        public DisplayBoard(ParkingLot pklot, FareRateManger fareRateManager)
        {
            this.parkingLot = pklot;
            this.fareRateManager = fareRateManager;
        }
        public void DisplayParkingLotStatus()
        {
            parkingLot.PrintParkingLot();
            DisplayAvailableSpots();            
        }

        private void DisplayAvailableSpots()
        {
            var availableSpots = parkingLot.GetAvailableSpots();
            Console.WriteLine("Available Parking Spots:");
            foreach (var spot in availableSpots)
            {
                Console.WriteLine(spot.ToString());
            }
        }
        public void DisplayFareRates()
        {
            fareRateManager.DisplayRate();
        }
        public double DisplayRateForSpotType(string spotType)
        {
            return fareRateManager.GetRate(spotType);
        }


    }
}