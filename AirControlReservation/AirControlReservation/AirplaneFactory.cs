using System;
namespace AirControlReservation;

public static class AirplaneFactory
{
	public static Airplane CreateAirplane(int numberOfRows = 40)
	{
        var rows = new Row[numberOfRows];

        for (var i = 0; i < numberOfRows; i += 1)
        {
            var row = new Row();
            var letterIndex = 0;
            foreach (ColumnLetter c in Enum.GetValues<ColumnLetter>())
            {
                row.Seats[letterIndex] = new Seat()
                {
                    Column = c,
                    Row = i + 1,
                    Passenger = new Passenger()
                    {
                        FirstName = "BILL"
                    }
                };
                letterIndex += 1;
            }
            rows[i] = row;
        }

        return new Airplane()
        {
            Rows = rows
        };
    }
}

