
// See https://aka.ms/new-console-template for more information
using AirControlReservation;
using AirControlReservation.Menu;
using Microsoft.Extensions.DependencyInjection;

//var aircontrol = new AirControl(new SaveFile());

//aircontrol.Start();

//// Create a task to an interface that can save the flight manifest
//// one implementation to save in memory
//// one to save it in the file
//// Consumer will use in the interface for dependency injection

//Console.Read();
var serviceCollection = new ServiceCollection();
var serviceProvider = serviceCollection.AddSingleton<MainScreen, MainScreen>()
    .AddSingleton<SeatClassSelectionScreen, SeatClassSelectionScreen>()
    .AddSingleton<IAskSeatService, AskSeatService>()
    .AddSingleton<BusinessClassSeatSelection, BusinessClassSeatSelection>()
    .AddSingleton<EconomyClassSeatSelectionScreen, EconomyClassSeatSelectionScreen>()
    .AddSingleton<SeatVerificationScreen, SeatVerificationScreen>()
    .AddSingleton<IStorage, SaveFile>()
.BuildServiceProvider();
ICommand? currentScreen = serviceProvider.GetService<MainScreen>();
do
{
    currentScreen = currentScreen?.Execute();
} while (currentScreen != null);

Console.WriteLine("Good Bye!");
Console.ReadKey();