using System;
using AirControlReservation.Enums;
using AirControlReservation.Models;

namespace AirControlReservation.Interfaces
{
	public interface ISeatSelector
    {
		public Task<Seat> AskSeat(int rowStart, int numberOfRows);
	}
}

