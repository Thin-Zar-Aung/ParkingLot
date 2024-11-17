using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.VehicleControl
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(String LicenseType,String Type)
        {
            switch (Type)
            {
                case "Truck":
                    return new Truck(LicenseType, Type);
                case "Motorcycle":
                    return new Motorcycle(LicenseType, Type);
                case "Car":
                    return new Car(LicenseType, Type);
                case "Van":
                    return new Van(LicenseType, Type);
                default:throw new ArgumentException("Invalid Vehicle Class Name");

            }

        }
    }
}
