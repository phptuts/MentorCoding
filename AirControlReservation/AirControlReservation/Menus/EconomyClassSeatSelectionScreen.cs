using System;
namespace AirControlReservation.Menus;
using AirControlReservation.Interfaces;


public class EconomyClassSeatSelectionScreen: SeatSelectionScreen
{
    public EconomyClassSeatSelectionScreen(IServiceProvider serviceProvider, IStorage storage, IAskSeatService askSeatService) : base(serviceProvider, storage, askSeatService, 6, 34, "Economy Class")
    {
	}
}


