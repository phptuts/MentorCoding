using System;
namespace AirControlReservation.Menu;

public abstract class Screen : ICommand
{
    public Screen(string title, Menu menu)
    {
        Title = title;
        Menu = menu;
    }

	public string Title { get; set; }

	public Menu Menu { get; set; }

    public abstract ICommand? Execute();

    public virtual void DrawHeader()
    {
        // 6 there will be a "** " on each side
        var lengthOfStarBar = Menu.Title.Length + 6;
        DrawStarBar(lengthOfStarBar);
        Console.WriteLine($"** {Menu.Title} **");
        DrawStarBar(lengthOfStarBar);
    }

    private void DrawStarBar(int length)
    {
        for (var i = 0; i < length; i += 1)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }

}


