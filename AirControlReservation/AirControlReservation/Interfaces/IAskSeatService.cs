using System;
using AirControlReservation.Enums;

namespace AirControlReservation.Interfaces
{
	public interface IAskSeatService
	{
		public (ColumnLetter, int, bool) AskSeat(int rowStart, int numberOfRows);
	}
}

