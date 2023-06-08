
using System;
using Microsoft.Extensions.DependencyInjection;

namespace AirControlReservation.Menu;

public abstract class SeatSelectionScreen : Screen
{
    private IServiceProvider _serviceProvider { get; }
    public IStorage _storage { get; }
    public int RowStart { get;  }

    public int NumberOfRows { get;  }

    public SeatSelectionScreen(IServiceProvider serviceProvider, IStorage storage, int rowStart, int numberOfRows, string title) :
        base(title, new Menu(title, "Please enter the row number: "))
    {
        _serviceProvider = serviceProvider;
        _storage = storage;
        RowStart = rowStart;
        NumberOfRows = numberOfRows;
    }

    public override ICommand? Execute()
    {
        Console.WriteLine();
        DrawHeader();
        PrintSeats(RowStart, NumberOfRows);
        Console.WriteLine();
        Console.Write(Menu.Prompt);
        int.TryParse(Console.ReadLine(), out var rowNumber);
        while (rowNumber < RowStart || rowNumber > RowStart + NumberOfRows)
        {
            Console.WriteLine("Invalid Entry! Please try again.");
            int.TryParse(Console.ReadLine(), out rowNumber);
        }

        Console.Write("Please enter the seat letter: ");
        var seatColumn = Convert.ToChar(Console.ReadLine() ?? "");

        while (!IsColumnSeatValid(seatColumn))
        {
            Console.WriteLine();
            Console.WriteLine(GeneralConstants.InvalidInputStr);
            Console.Write("Please enter the seat letter: ");

            seatColumn = Convert.ToChar(Console.ReadLine() ?? "");
        }
        var seatColumnEnum = GetColumnLetter(seatColumn);


        return _serviceProvider.GetService<MainScreen>();
    }

    protected void PrintSeats(int start, int end)
    {
        Console.WriteLine("    A B C D E");
        for (var i = start; i < end; i += 1)
        {
            Console.Write($"  {i + 1} ");
            foreach (var seat in _storage.Airplane.Rows[i].Seats)
            {
                Console.Write(seat.Taken() ? "X" : " ");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

}


