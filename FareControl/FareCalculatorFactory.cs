using ParkingLotSource.ParkingSpotControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public class FareCalculatorFactory
    {
           public FareCalculator CreateFareCalculator(ParkingSpot spot, FareRateManger fareSettings)
            {
                IFareStrategy strategy;

                switch (spot.SpotType)
                {
                    case "Small":
                        strategy = new SmallSpotFareStrategy(fareSettings);
                        break;
                    case "Regular":
                        strategy = new RegularSpotFareStrategy(fareSettings);
                        break;
                    case "Large":
                        strategy = new LargeSpotFareStrategy(fareSettings);
                        break;
                    default:
                        throw new ArgumentException("Unsupported parking spot type");
                }

                return new FareCalculator(strategy);
            }
        }
    }