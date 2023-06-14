using System;
using Microsoft.Extensions.DependencyInjection;
using AirControlReservation.Interfaces;
using AirControlReservation.Constants;
using Microsoft.VisualBasic.FileIO;

namespace AirControlReservation.Menus;

public class MainScreen: Screen
{
    private IServiceProvider _serviceProvider { get; }

    public MainScreen(IServiceProvider serviceProvider):
        base("Welcome to AirConsole", new Menu("Task Selection", "Please enter the task you want to perform? "))
	{
        _serviceProvider = serviceProvider;
        Menu.AddMenuItem('R', new MenuItem('R', "Reservation", new Lazy<ICommand>(() => _serviceProvider.GetService<SeatClassSelectionScreen>())));
        Menu.AddMenuItem('S', new MenuItem('S', "Seat Verification", new Lazy<ICommand>(() => _serviceProvider.GetService<SeatVerificationScreen>())));
        Menu.AddMenuItem('X', new MenuItem('X', "Exit the System", new Lazy<ICommand>(() => null)));
    }

    public override Task<ICommand?> Execute()
    {
        DrawHeader();
        Console.WriteLine("Task Selection");
        foreach (var menuOption in Menu.MenuItems)
        {
            Console.WriteLine($"{menuOption.Key}: {menuOption.Value.Name}");
        }
        Console.WriteLine();
        Console.Write(Menu.Prompt);
        char option;
        var isValidOption = char.TryParse(Console.ReadLine(), out option);
        while (!isValidOption)
        {
            Console.WriteLine(GeneralConstants.InvalidInputStr);
            Console.WriteLine(Menu.Prompt);
            isValidOption = char.TryParse(Console.ReadLine(), out option);
        }

        while (!Menu.MenuItems.ContainsKey(option))
        {
            Console.WriteLine(GeneralConstants.InvalidInputStr);
            Console.WriteLine(Menu.Prompt);
            char.TryParse(Console.ReadLine(), out option);
        }

        return Task.FromResult(Menu.MenuItems[option].Command.Value);
    }
}


