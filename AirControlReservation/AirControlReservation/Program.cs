
// See https://aka.ms/new-console-template for more information
using AirControlReservation;

var aircontrol = new AirControl(new SaveFile());

aircontrol.Start();

// Create a task to an interface that can save the flight manifest
// one implementation to save in memory
// one to save it in the file
// Consumer will use in the interface for dependency injection

Console.Read();

