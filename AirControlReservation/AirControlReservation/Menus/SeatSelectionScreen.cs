
using System;
using Microsoft.Extensions.DependencyInjection;
using AirControlReservation.Interfaces;
using AirControlReservation.Models;
using AirControlReservation.Enums;

namespace AirControlReservation.Menus;

public abstract class SeatSelectionScreen : Screen
{
    private IServiceProvider _serviceProvider { get; }
    public IStorage _storage { get; }
    public IAskSeatService _askSeatService { get; }
    public int RowStart { get;  }

    public int NumberOfRows { get;  }

    public SeatSelectionScreen(IServiceProvider serviceProvider, IStorage storage, IAskSeatService askSeatService, int rowStart, int numberOfRows, string title) :
        base(title, new Menu(title, "Please enter the row number: "))
    {
        _serviceProvider = serviceProvider;
        _storage = storage;
        _askSeatService = askSeatService;
        RowStart = rowStart;
        NumberOfRows = numberOfRows;
    }

    public override ICommand? Execute()
    {
        Console.WriteLine();
        DrawHeader();
        PrintSeats();

        var (columnLetter, rowNumber) = FindSeat();
        Console.Write("Please enter the passenger's firstname: ");
        var firstName = Console.ReadLine() ?? " ";
        Console.Write("Please enter the passenger's lastname: ");
        var lastName = Console.ReadLine() ?? " ";
        Console.Write("Please enter the passenger's passport number: ");
        var passPortNumber = Console.ReadLine() ?? " ";
        _storage.Airplane.Book(rowNumber, columnLetter, new Passenger()
        {
            FirstName = firstName,
            LastName = lastName,
            PassPortNumber = passPortNumber
        });
        // TODO REFACTOR TO BOOK METHOD IN ISTORAGE
        _storage.Save();
        Console.WriteLine();
        Console.WriteLine($"Seat {rowNumber}{columnLetter} was successfully booked!");
        Console.WriteLine();

        return _serviceProvider.GetService<MainScreen>();
    }

    protected (ColumnLetter, int) FindSeat()
    {
        
        while(true)
        {
            var (seatColumn, rowNumber, isTaken) = _askSeatService.AskSeat(RowStart, NumberOfRows);

            if (!isTaken)
            {
                return (seatColumn, rowNumber);
            }

            Console.WriteLine($"Sorry seat {rowNumber}{seatColumn} is already taken.");
        }
    }



    protected void PrintSeats()
    {
        Console.WriteLine("    A B C D E");
        for (var i = RowStart; i < RowStart + NumberOfRows; i += 1)
        {
            Console.Write($"  {i} ");
            foreach (var seat in _storage.Airplane.Rows[i - 1].Seats)
            {
                Console.Write(seat.Taken() ? "X" : " ");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }


}


