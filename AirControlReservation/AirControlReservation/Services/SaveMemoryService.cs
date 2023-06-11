using System;
using AirControlReservation.Interfaces;
using AirControlReservation.Models;
using AirControlReservation.Factories;

namespace AirControlReservation.Services;

public class SaveMemoryService : IStorage
{
    private Airplane? _airplane;

    public Airplane Airplane
    {
        get
        {
            if (_airplane is null)
            {
                var airplane = AirplaneFactory.CreateAirplane();
                return airplane;
            }

            return _airplane;
        }
        private set
        {
            _airplane = value;
        }
    }

    public Task Save()
    {
        return Task.CompletedTask;
    }
}

