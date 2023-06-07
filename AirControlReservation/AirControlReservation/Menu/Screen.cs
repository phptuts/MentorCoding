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
        var starBar = $"*******************************";
        var numberOfStarsOnEachSide = 4;
        var wordLength = Menu.Title.Length;
        var spacesTaken = (wordLength + numberOfStarsOnEachSide);
        var lengthOfSide = starBar.Length;
        var leftOverSpace = lengthOfSide - spacesTaken;
        var paddingLeftSide = leftOverSpace / 2;
        var paddingRightSide = lengthOfSide - (spacesTaken + paddingLeftSide);
        Console.WriteLine(starBar);
        Console.Write("**");
        for (var i = 0; i < paddingLeftSide; i += 1)
        {
            Console.Write(" ");
        }
        Console.Write(Menu.Title);
        for (var i = 0; i < paddingRightSide; i += 1)
        {
            Console.Write(" ");
        }
        Console.Write("**");
        Console.WriteLine();
        Console.WriteLine(starBar);
        Console.WriteLine();
    }

}


