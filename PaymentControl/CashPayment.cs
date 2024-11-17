using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.PaymentControl
{
    public class CashPayment : Ipayment
    {
        private double _cashTendered;
        private double _parkingFee;
        private double _change;
        private string _status;

       

        public CashPayment(double cashTendered, double parkingFee)
        {
            _cashTendered = cashTendered;
            _parkingFee = parkingFee;
            _status = "Pending";
        }

       

   
        public string ProcessPayment()
        {
            if (_cashTendered >= _parkingFee)
            {
                _change = _cashTendered - _parkingFee;
                _status = "Success";
                Console.WriteLine($"Payment Status: {_status}");
                Console.WriteLine($"ParkingFess:{_parkingFee}");
                Console.WriteLine($"Cashtendered:{_cashTendered}");
                Console.WriteLine($"Receive Your Change: {_change}");
            }
            else
            {
                _change = 0;
                _status = "Failed";
                Console.WriteLine($"Payment Status: {_status}");
                Console.WriteLine($"ParkingFess:{_parkingFee}");
                Console.WriteLine($"Cashtendered:{_cashTendered}");
                Console.WriteLine($"Cash received is not enough to pay parkingfees");
            }
            
            return _status;
        }
    }
}
