using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.FareControl
{
    public class FareRateManger
    {
        private Dictionary<string, double> Dicrates;
        public FareRateManger()
        {
            Dicrates = new Dictionary<string, double>();
        }
        public double GetRate(string spotType)
        {
            return Dicrates[spotType];
        }
        public void DisplayRate()
        {
           foreach(var keys in Dicrates.Keys)
            {
                Console.WriteLine(keys+ " Rate: "+ "Spot Fare:  " + Dicrates[keys] + "$");
             
            }
        }

        public void setRate(string spotType, double rate)
        {
            
            if (!Dicrates.ContainsKey(spotType))
            {
                Dicrates[spotType] = rate;

            }
            
            else {throw new ArgumentException("Rate setting for spot type is already exist"); }
        }
    }
}
