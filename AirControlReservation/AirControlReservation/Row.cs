using System;
namespace AirControlReservation;

public class Row
{
    public Seat[] Seats { get; set; } = new Seat[Enum.GetValues<ColumnLetter>().Length];
}

