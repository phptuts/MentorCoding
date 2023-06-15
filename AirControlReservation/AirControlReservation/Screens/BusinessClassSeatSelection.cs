using System;
using AirControlReservation.Interfaces;
using AirControlReservation.Models;

namespace AirControlReservation.Screens;

public class BusinessClassSeatSelection: SeatSelectionScreen
{
	// Communicates the purpose of the class by giving it's own name
    public BusinessClassSeatSelection(IServiceProvider serviceProvider, IStorage<Seat, string> storage, ISeatSelector seatSelector): base(serviceProvider, storage, seatSelector, 1, 5, "Business Class")
	{
    }
}

