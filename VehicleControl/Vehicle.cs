using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.VehicleControl
{
    public abstract class Vehicle
    {
        private string License;
        public string Type {  get; set; }
        public Vehicle(string license, string type)
        {
            this.License = license;
            this.Type = type;
        }
        public string getLicense()
        {
            return License;
        }

    }
}
