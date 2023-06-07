using System;
namespace AirControlReservation.Menu;

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


