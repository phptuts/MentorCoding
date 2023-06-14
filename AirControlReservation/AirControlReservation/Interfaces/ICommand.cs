using System;
namespace AirControlReservation.Interfaces;

public interface ICommand
{
	public Task<ICommand?> Execute();
}


