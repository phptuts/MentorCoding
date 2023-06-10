using System;
namespace AirControlReservation.Menu
{
	public interface IAskSeatService
	{
		public (ColumnLetter, int, bool) AskSeat(int rowStart, int numberOfRows);
	}
}

