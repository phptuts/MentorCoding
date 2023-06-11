using System;
using AirControlReservation.Models;

namespace AirControlReservation.Interfaces;

public interface IStorage
{
    public Airplane Airplane { get; }

    public Task Save();
}


