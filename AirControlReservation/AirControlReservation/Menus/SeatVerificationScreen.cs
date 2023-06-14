using System;
using Microsoft.Extensions.DependencyInjection;
using AirControlReservation.Interfaces;
using AirControlReservation.Enums;
using AirControlReservation.Models;

namespace AirControlReservation.Menus
{
	public class SeatVerificationScreen: Screen
	{
        private IServiceProvider _serviceProvider { get; }
        public ISeatSelector _seatSelector { get; }

        public SeatVerificationScreen(IServiceProvider serviceProvider, ISeatSelector seatSelector)
            : base("Seat Verification", new Menu("Seat Verification", "Please enter the row number: "))
		{
			_serviceProvider = serviceProvider;
            _seatSelector = seatSelector;
		}

        public async override Task<ICommand?> Execute()
        {
            var seat = await _seatSelector.AskSeat(1, 40);

            if (seat.Taken())
            {
                var passenger = seat.Passenger;
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

