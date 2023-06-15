
using System;
using Microsoft.Extensions.DependencyInjection;
using AirControlReservation.Interfaces;
using AirControlReservation.Models;
using AirControlReservation.Enums;
using AirControlReservation.Menus;

namespace AirControlReservation.Screens;

public abstract class SeatSelectionScreen : Screen
{
    private IServiceProvider _serviceProvider { get; }
    public IStorage<Seat, string> _storage { get; }
    public ISeatSelector _seatSelector { get; }
    public int RowStart { get;  }

    public int NumberOfRows { get;  }

    public SeatSelectionScreen(IServiceProvider serviceProvider, IStorage<Seat, string> storage, ISeatSelector seatSelector, int rowStart, int numberOfRows, string title) :
        base(title, new Menu(title, "Please enter the row number: "))
    {
        _serviceProvider = serviceProvider;
        _storage = storage;
        _seatSelector = seatSelector;
        RowStart = rowStart;
        NumberOfRows = numberOfRows;
    }

    public override async Task<ICommand?> Execute()
    {
        Console.WriteLine();
        DrawHeader();
        await PrintSeats();

        var seat = await FindSeat();
        Console.Write("Please enter the passenger's firstname: ");
        var firstName = Console.ReadLine() ?? " ";
        Console.Write("Please enter the passenger's lastname: ");
        var lastName = Console.ReadLine() ?? " ";
        Console.Write("Please enter the passenger's passport number: ");
        var passPortNumber = Console.ReadLine() ?? " ";
        seat.Passenger = new Passenger()
        {
            FirstName = firstName,
            LastName = lastName,
            PassPortNumber = passPortNumber
        };
        await _storage.Create(seat);
        Console.WriteLine();
        Console.WriteLine($"Seat {seat.Row}{seat.Column} was successfully booked!");
        Console.WriteLine();

        return _serviceProvider.GetService<MainScreen>();
    }

    protected async Task<Seat> FindSeat()
    {
        
        while(true)
        {
            var seat = await _seatSelector.AskSeat(RowStart, NumberOfRows);

            if (!seat.Taken())
            {
                return seat;
            }

            Console.WriteLine($"Sorry seat {seat.Row}{seat.Column} is already taken.");
        }
    }



    protected async Task PrintSeats()
    {
        Console.WriteLine("    A B C D E");
        for (var i = RowStart; i < RowStart + NumberOfRows; i += 1)
        {
            Console.Write($"  {i} ");
            foreach (var columnLetter in Enum.GetValues<ColumnLetter>())
            {
                var seat = await _storage.Get($"{i}{columnLetter}");
                Console.Write(seat is Seat ? "X" : " ");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }


}


