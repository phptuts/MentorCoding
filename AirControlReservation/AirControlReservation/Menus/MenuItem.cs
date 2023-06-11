using System;
using AirControlReservation.Interfaces;

namespace AirControlReservation.Menus;

public class MenuItem
{
	public char ShortCut;

	public string Name;

	public Lazy<ICommand> Command;

	public MenuItem(char shortCut, string name, Lazy<ICommand> command)
	{
		ShortCut = shortCut;
		Name = name;
		Command = command;
	}
}


