using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.PaymentControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.UserControl
{
    public class AdminUserConfigurationService
    {
        private ParkingSpotManager parkingSpotManager;
        private FareRateManger fareRateManger;
        private PaymentService paymentService;
        private FareCalculatorFactory fareCalculatorFactory;
        public AdminUserConfigurationService(ParkingSpotManager parkingSpotManager, FareRateManger fareRateManger, PaymentService paymentService, FareCalculatorFactory fareCalculatorFactory)
        {
            this.parkingSpotManager = parkingSpotManager;
            this.fareRateManger = fareRateManger;
            this.paymentService = paymentService;
            this.fareCalculatorFactory = fareCalculatorFactory;
        }

        public AdminUser CreateAdminUser(int id, string name)
        {
            AdminUser adminUser= new AdminUser(id, name);
            adminUser.Configure(this.parkingSpotManager, this.fareRateManger, this.paymentService, this.fareCalculatorFactory);
            return adminUser;
        }
    }
}
