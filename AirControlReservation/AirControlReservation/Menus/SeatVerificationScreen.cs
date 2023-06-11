using System;
using Microsoft.Extensions.DependencyInjection;
using AirControlReservation.Interfaces;
using AirControlReservation.Enums;

namespace AirControlReservation.Menus
{
	public class SeatVerificationScreen: Screen
	{
        private IServiceProvider _serviceProvider { get; }
        public IAskSeatService _askSeatService { get; }
        public IStorage _storage { get; }

        public SeatVerificationScreen(IServiceProvider serviceProvider, IAskSeatService askSeatService, IStorage storage)
            : base("Seat Verification", new Menu("Seat Verification", "Please enter the row number: "))
		{
			_serviceProvider = serviceProvider;
            _askSeatService = askSeatService;
            _storage = storage;
		}

        public override ICommand? Execute()
        {
            var (seatLetter, row, seatExists) = _askSeatService.AskSeat(1, 40);

            if (seatExists)
            {
                var passenger = _storage.Airplane.GetPassenger(row, seatLetter);
                Console.WriteLine($"Passenger Details");
                Console.WriteLine($"Firstname: {passenger?.FirstName}");
                Console.WriteLine($"Lastname: {passenger?.LastName}");
                Console.WriteLine($"Passport Number: {passenger?.PassPortNumber}");
            }
            else
            {
                Console.WriteLine("Seat is still available.");
            }
            Console.WriteLine();
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.WriteLine();

            return _serviceProvider.GetService<MainScreen>();
        }
    }
}

