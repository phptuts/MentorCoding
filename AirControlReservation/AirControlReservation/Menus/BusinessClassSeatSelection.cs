using System;
using AirControlReservation.Interfaces;

namespace AirControlReservation.Menus
{
	public class BusinessClassSeatSelection: SeatSelectionScreen
	{
		// Communicates the purpose of the class by giving it's own name
        public BusinessClassSeatSelection(IServiceProvider serviceProvider, IStorage storage, IAskSeatService askSeatService): base(serviceProvider, storage, askSeatService, 1, 5, "Business Class")
		{
        }
	}
}

