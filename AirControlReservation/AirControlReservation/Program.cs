
// See https://aka.ms/new-console-template for more information
using AirControlReservation;
using AirControlReservation.Menus;
using AirControlReservation.Interfaces;
using AirControlReservation.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
var serviceProvider = serviceCollection.AddSingleton<MainScreen, MainScreen>()
    .AddSingleton<SeatClassSelectionScreen, SeatClassSelectionScreen>()
    .AddSingleton<ISeatSelector, SeatSelector>()
    .AddSingleton<BusinessClassSeatSelection, BusinessClassSeatSelection>()
    .AddSingleton<EconomyClassSeatSelectionScreen, EconomyClassSeatSelectionScreen>()
    .AddSingleton<SeatVerificationScreen, SeatVerificationScreen>()
    .AddSingleton<IStorage, SaveFileService>()
.BuildServiceProvider();
ICommand? currentScreen = serviceProvider.GetService<MainScreen>();
do
{
    currentScreen = currentScreen?.Execute();
} while (currentScreen != null);

Console.WriteLine("Good Bye!");
Console.ReadKey();