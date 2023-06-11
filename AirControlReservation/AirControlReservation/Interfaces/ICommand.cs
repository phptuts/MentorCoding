using System;
namespace AirControlReservation.Interfaces;

public interface ICommand
{
	public ICommand? Execute();
}


