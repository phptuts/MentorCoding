// See https://aka.ms/new-console-template for more information
namespace AirControlReservation;

public class Airplane
{
    public Row[] Rows { get; set; } = new Row[0];

    public bool IsSeatTake(int rowNumber, ColumnLetter seatColumn)
    {
        var row = Rows[rowNumber];
        return row.Seats.First(x => x.Column == seatColumn).Taken();
    }

    public void Book(int rowNumber, ColumnLetter seatColumn, Passenger passenger)
    {
        var row = Rows[rowNumber];
        var seat = row.Seats.First(x => x.Column == seatColumn);
        seat.Passenger = passenger;
    }
}



