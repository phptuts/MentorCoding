using System;
namespace AirControlReservation.Menu
{
	public class BusinessClassSeatSelection: SeatSelectionScreen
	{

        public BusinessClassSeatSelection(IServiceProvider serviceProvider, IStorage storage): base(serviceProvider, storage, 0, 5, "Business Class")
		{
        }
	}
}

