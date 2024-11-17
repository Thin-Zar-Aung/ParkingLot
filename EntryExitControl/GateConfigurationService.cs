using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.PaymentControl;
using ParkingLotSource.VehicleControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSource.EntryExitControl
{
    public class GateConfigurationService
    {
        private ParkingSpotManager parkingSpotManager;
        private FareCalculatorFactory fareCalculatorFactory;
        private VehicleFactory vehicleFactory;
        private PaymentService paymentService;
        private TicketService ticketService;
        private FareRateManger fareRateManger;
        public GateConfigurationService(ParkingSpotManager parkingSpotManager, VehicleFactory vehicleFactory, TicketService ticketService, FareCalculatorFactory fareCalculatorFactory, PaymentService paymentService, FareRateManger fareRateManger)
        {
            this.parkingSpotManager = parkingSpotManager;
            this.fareCalculatorFactory = fareCalculatorFactory;
            this.paymentService = paymentService;
            this.ticketService = ticketService;
            this.vehicleFactory = vehicleFactory;
            this.fareRateManger = fareRateManger;
        }

        public EntryGate CreateEntryGate(int id, string name)
        {
            EntryGate entryGate = new EntryGate(id, name);
            entryGate.Configure(ticketService,vehicleFactory,parkingSpotManager,fareRateManger);
            return entryGate;
        }

        public ExitGate CreateExitGate(int id, string name)
        {
            var exitGate = new ExitGate(id, name);
            exitGate.configure(parkingSpotManager,fareCalculatorFactory,paymentService, fareRateManger);
            return exitGate;
        }
    }
}

