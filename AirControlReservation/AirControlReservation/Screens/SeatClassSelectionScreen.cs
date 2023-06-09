﻿using System;
using Microsoft.Extensions.DependencyInjection;
using AirControlReservation.Interfaces;
using AirControlReservation.Constants;
using AirControlReservation.Menus;

namespace AirControlReservation.Screens;

public class SeatClassSelectionScreen : Screen
{
    private IServiceProvider _serviceProvider { get; }

    public SeatClassSelectionScreen(IServiceProvider serviceProvider) :
        base("Seat Class", new Menu("Seat Class Selection", "Please enter the seat class you want to reserve: "))
    {
        _serviceProvider = serviceProvider;
        Menu.AddMenuItem('B', new MenuItem('B', "Business Class", new Lazy<ICommand>(() => _serviceProvider.GetService<BusinessClassSeatSelection>())));
        Menu.AddMenuItem('E', new MenuItem('E', "Economy Class", new Lazy<ICommand>(() => _serviceProvider.GetService<EconomyClassSeatSelectionScreen>())));
        _serviceProvider = serviceProvider;
    }

    public override Task<ICommand?> Execute()
    {
        DrawHeader();
        Console.WriteLine("Seat Class Selection");
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


