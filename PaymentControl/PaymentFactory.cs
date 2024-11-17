using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.PaymentControl
{
    public class PaymentFactory
    {
        public Ipayment CreatePayment(double parkingFee, Ticket ticket, string paymentType, double cashTendered = 0, string nameOnCard = "")
        {
            switch (paymentType)
            {
                case "Cash":
                    return new CashPayment(cashTendered, parkingFee);
                case "Card":
                    return new CreditCardPayment((nameOnCard), parkingFee);
                default:
                    Console.WriteLine("Invalid Payment Type");
                    throw new Exception("Invalid payment");
            }

        }
    }
}
