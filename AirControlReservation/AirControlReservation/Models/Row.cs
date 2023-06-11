using System;
using AirControlReservation.Enums;

namespace AirControlReservation.Models;

public class Row
{
    public Seat[] Seats { get; set; } = new Seat[Enum.GetValues<ColumnLetter>().Length];
}

