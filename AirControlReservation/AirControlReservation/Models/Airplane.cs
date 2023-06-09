﻿// See https://aka.ms/new-console-template for more information
using AirControlReservation.Enums;
namespace AirControlReservation.Models;

public class Airplane
{
    public Row[] Rows { get; set; } = new Row[0];

    public bool IsSeatTaken(int rowNumber, ColumnLetter seatColumn)
    {
        var row = Rows[rowNumber - 1];
        return row.Seats.First(x => x.Column == seatColumn).Taken();
    }

    public Seat GetSeat(int rowNumber, ColumnLetter seatColumn)
    {
        var row = Rows[rowNumber - 1];
        return row.Seats.First(x => x.Column == seatColumn);
    }

    public Passenger? GetPassenger(int rowNumber, ColumnLetter seatColumn)
    {
        return GetSeat(rowNumber, seatColumn)?.Passenger ?? null;
    }

    public void Book(int rowNumber, ColumnLetter seatColumn, Passenger passenger)
    {
        var row = Rows[rowNumber - 1];
        var seat = row.Seats.First(x => x.Column == seatColumn);
        seat.Passenger = passenger;
    }
}



