using System;
using ParkingLotSource.PaymentControl;

namespace ParkingLotSource.PaymentControl
{
    public class CreditCardPayment :Ipayment
    {
        private string _nameOnCard;
        private double _parkingFee;
        private string _status;

       
        public CreditCardPayment(string nameOnCard, double parkingFee)
        {
            _nameOnCard = nameOnCard;
            _parkingFee = parkingFee;
            _status = "Pending";
        }

        public string ProcessPayment()
        {
           

            if (ValidateCardDetails())
            {
                _status = "Success";
                DisplayPaymentResult();
            }
            else
            {
                _status = "Failed";
                DisplayPaymentResult();
            }
            return _status;
        }

        private bool ValidateCardDetails()
        {
            return !string.IsNullOrWhiteSpace(_nameOnCard) && _parkingFee > 0;
        }

        
        private void DisplayPaymentResult()
        {
            Console.WriteLine($"Payment Status: {_status}");
            Console.WriteLine($"Amount Charged: {_parkingFee}");
        }
    }
}
