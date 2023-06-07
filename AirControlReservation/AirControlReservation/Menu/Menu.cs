using System;
namespace AirControlReservation.Menu;

public class Menu
{
    public string Title { get; }
    public string Prompt { get; }
    public Dictionary<char, MenuItem> MenuItems { get; private set; } = new Dictionary<char, MenuItem>();


    public Menu(string title, string prompt)
	{
        Title = title;
        Prompt = prompt;
    }

    public void AddMenuItem(char key, MenuItem item)
    {
        MenuItems[key] = item;
    }

}


