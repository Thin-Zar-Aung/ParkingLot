using System;
using ParkingLotSource.EntryExitControl;
using ParkingLotSource.FareControl;
using ParkingLotSource.ParkingLotControl;
using ParkingLotSource.ParkingSpotControl;
using ParkingLotSource.PaymentControl;
using ParkingLotSource.UserControl;
using ParkingLotSource.VehicleControl;

class Program
{
    static void Main(string[] args)
    {
        // Test Setup
        Console.WriteLine("Create a parkinglot");
        ParkingSpotManager parkingSpotManager = new ParkingSpotManager();
        GateManager gateManager = new GateManager();
        ParkingLot parkingLot = new ParkingLot("Test Parking lot", 1, "123 Test Street", parkingSpotManager,gateManager);
        //Create parking spot with parkingspotmanager class      
        Console.WriteLine("Create Parking spots");
        parkingSpotManager.AddSpot(new ParkingSpot(1, "Regular", false));
        parkingSpotManager.AddSpot(new ParkingSpot(2, "Small", false));
        parkingSpotManager.AddSpot(new ParkingSpot(3, "Large", false));
        PaymentFactory paymentFactory = new PaymentFactory();
        PaymentService paymentService = new PaymentService(paymentFactory);
        FareRateManger fareRateManger = new FareRateManger();
        FareCalculatorFactory fareCalculatorFactory = new FareCalculatorFactory();
        
        AdminUserConfigurationService adminService = new AdminUserConfigurationService(parkingSpotManager, fareRateManger, paymentService, fareCalculatorFactory);
        AdminUser adminUser = adminService.CreateAdminUser(1, "Admin Test");

        Console.WriteLine("Create Entry and Exit Gate");
        
        VehicleFactory vehicleFactory = new VehicleFactory();
        TicketService ticketservice = new TicketService();
        GateConfigurationService gateService = new GateConfigurationService(parkingSpotManager, vehicleFactory, ticketservice, fareCalculatorFactory, paymentService, fareRateManger);
        EntryGate entryGate = gateService.CreateEntryGate(1, "Entry Test Gate");
        ExitGate exitGate = gateService.CreateExitGate(1, "Exit Test Gate");
       
        gateManager.AddEntryGate(entryGate);
        gateManager.AddExitGate(exitGate);
        parkingLot.PrintParkingLot();
        DisplayBoard display = new DisplayBoard(parkingLot,fareRateManger);
        // Run Tests
        TestAdminUserFunctionality(adminUser, parkingLot,display);       
        UserWithCashPayment( entryGate,exitGate,display, paymentService, fareRateManger);
        UserWithCreditPayment(entryGate, exitGate, display, paymentService, fareRateManger);
        UserWithPayMentFail(entryGate, exitGate, display, paymentService, fareRateManger,adminUser);
    }

    static void TestAdminUserFunctionality(AdminUser adminUser, ParkingLot parkingLot,DisplayBoard display)
    {
        Console.WriteLine("\n[TEST] Admin User Functionality");
        Console.WriteLine("Admin add the parking spot");
        adminUser.AddParkingSpot(4, "Regular", true);
        adminUser.AddParkingSpot(5, "Small", true);
        adminUser.AddParkingSpot(6, "Large", true);
        adminUser.AddParkingSpot(7, "Regular", false);
        adminUser.AddParkingSpot(8, "Small", false);
        adminUser.AddParkingSpot(9, "Large", false);
        Console.WriteLine("Admin added parking spots successfully.");
        Console.WriteLine("\n[INFO] Current Parking Spots:");
        foreach (ParkingSpot spot in parkingLot.GetAllSpots())
        {
            Console.WriteLine(spot.ToAdminString());
        }
        Console.WriteLine("\nAdmin set the parking spot rate");
        adminUser.SetRate("Regular", 7.0);
        adminUser.SetRate("Small", 5.0);
        adminUser.SetRate("Large", 10.0);
        adminUser.DisplayFareRates(display);
      
       
        adminUser.RemoveParkingSpot(2);
        Console.WriteLine("\n Admin removed parking spot with ID 2.");

        Console.WriteLine("\n[INFO] Parking Spots After Removal:");
        foreach (ParkingSpot spot in parkingLot.GetAllSpots())
        {
            Console.WriteLine(spot.ToAdminString());
        }
        Console.WriteLine("................................................");
    }  

    static void UserWithCashPayment( EntryGate entryGate,ExitGate exitGate, DisplayBoard display, PaymentService paymentService,FareRateManger fareRateManager)
    {
        NormalUser user = new NormalUser();
        Console.WriteLine("\n[TEST] User check the displayboard");
        user.DisplayParkingLotInfo(display);
        Console.WriteLine("\n[TEST] Make Gate Entry Process");     
        Ticket ticket =user.GetTicket("License123", "Car", true, entryGate,user.id,user.name);
        Console.WriteLine("\n[TEST] Receive Ticket Detial");
        user.ViewTicketDetails(ticket, display);
        Console.WriteLine("\nProcess for vehicle exit...");
        double fare = user.GetParkingFee(ticket, exitGate);
        Console.WriteLine($"Calculated Fare: {fare}");

        // Test Cash Payment
        Console.WriteLine("\nTesting User Make Cash Payment...");
        Console.WriteLine("");
        string cashPaymentStatus = paymentService.ProcessPayment(fare, ticket, "Cash", 20.0);
        Console.WriteLine($"Cash Payment Status: {cashPaymentStatus}");
        Console.WriteLine("................................................");

    }
    static void UserWithCreditPayment(EntryGate entryGate, ExitGate exitGate, DisplayBoard display, PaymentService paymentService,FareRateManger fareRateManger)
    {
        NormalUser user = new NormalUser();
        Console.WriteLine("\n[TEST] User check the displayboard");
        user.DisplayParkingLotInfo(display);
        Console.WriteLine("\n[TEST] Make Gate Entry Process");
        Ticket ticket = user.GetTicket("License124", "Motorcycle", true, entryGate, user.id, user.name);
        Console.WriteLine("\n[TEST] Receive Ticket Detial");
        user.ViewTicketDetails(ticket, display);
        Console.WriteLine("\nProcess for vehicle exit...");
        double fare = user.GetParkingFee(ticket, exitGate);
        Console.WriteLine($"Calculated Fare: {fare}");
        Console.WriteLine("");
        // Test Cash Payment
        Console.WriteLine("Testing User Make Credit Payment...");
        string CreditPaymentStatus = paymentService.ProcessPayment(fare, ticket, "Card",0,"Miyao");
        Console.WriteLine($"Credit Payment Status: {CreditPaymentStatus}");
        Console.WriteLine("................................................");

    }
    static void UserWithPayMentFail(EntryGate entryGate, ExitGate exitGate, DisplayBoard display, PaymentService paymentService, FareRateManger fareRateManger,AdminUser adminUser)
    {
        NormalUser user = new NormalUser();
        Console.WriteLine("\n[TEST] User check the displayboard");
        user.DisplayParkingLotInfo(display);
        Console.WriteLine("\n[TEST] Make Gate Entry Process");
        Ticket ticket = user.GetTicket("License125", "Truck", true, entryGate, user.id, user.name);
        Console.WriteLine("\n[TEST] Receive Ticket Detial");
        user.ViewTicketDetails(ticket, display);
        Console.WriteLine("\nProcess for vehicle exit...");
        double fare = user.GetParkingFee(ticket, exitGate);
        Console.WriteLine($"Calculated Fare: {fare}");
        Console.WriteLine("");
        // Test Cash Payment
        Console.WriteLine("\nTesting Payment failed and payment done by Admin...");
        string cashPaymentStatus = paymentService.ProcessPayment(fare, ticket, "Cash", 7.0);
        Console.WriteLine($"Cash Payment Status: {cashPaymentStatus}");
        Console.WriteLine("Request admin to make payment");
        adminUser.ManagePaymentFailure(ticket,"Cash",10,20);
        Console.WriteLine("................................................");

    }
}
