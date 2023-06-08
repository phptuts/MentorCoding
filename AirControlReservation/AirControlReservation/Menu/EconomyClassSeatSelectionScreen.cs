using System;
namespace AirControlReservation.Menu;

public class EconomyClassSeatSelectionScreen: SeatSelectionScreen
{
    public EconomyClassSeatSelectionScreen(IServiceProvider serviceProvider, IStorage storage) : base(serviceProvider, storage, 5, 40, "Economy Class")
    {
	}
}


