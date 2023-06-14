using System;
namespace AirControlReservation.Menus;
using AirControlReservation.Interfaces;
using AirControlReservation.Models;


public class EconomyClassSeatSelectionScreen: SeatSelectionScreen
{
    public EconomyClassSeatSelectionScreen(IServiceProvider serviceProvider, IStorage<Seat, string> storage, ISeatSelector seatSelector) : base(serviceProvider, storage, seatSelector, 6, 34, "Economy Class")
    {
	}
}


