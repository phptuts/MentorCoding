// See https://aka.ms/new-console-template for more information

using AirControlReservation.Enums;

namespace AirControlReservation.Models;

public class Seat
{
    public string Id {
        get
        {
            return $"{Row}{Column}";
        }
    }

    public ColumnLetter Column { get; set; }

    public int Row { get; set; }

    public Passenger? Passenger { get; set; }

    public bool IsBusinessClass()
    {
        return Row <= 2;
    }

    public bool Taken()
    {
        return Passenger is not null;
    }
}



