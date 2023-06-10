using System;
namespace AirControlReservation.Menu;

public class EconomyClassSeatSelectionScreen: SeatSelectionScreen
{
    public EconomyClassSeatSelectionScreen(IServiceProvider serviceProvider, IStorage storage, IAskSeatService askSeatService) : base(serviceProvider, storage, askSeatService, 6, 34, "Economy Class")
    {
	}
}


