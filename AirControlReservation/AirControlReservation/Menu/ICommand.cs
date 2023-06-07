using System;
namespace AirControlReservation.Menu;

public interface ICommand
{
	public ICommand? Execute();
}


