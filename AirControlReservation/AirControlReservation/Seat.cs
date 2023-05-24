// See https://aka.ms/new-console-template for more information
namespace AirControlReservation;

public class Seat
{
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



