using ParkingLotSource.EntryExitControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.PaymentControl
{
    public class PaymentService
    {
        private PaymentFactory factory;
        public PaymentService(PaymentFactory factory)
        {
            this.factory = factory;
        }
         public string ProcessPayment(double parkingFee, Ticket ticket, string paymentType, double cashTendered, string nameOnCard="")
        {

            Ipayment payment = factory.CreatePayment(parkingFee, ticket, paymentType, cashTendered, nameOnCard);


            string paymentStatus = payment.ProcessPayment();


            return paymentStatus;
        }
    }
}
