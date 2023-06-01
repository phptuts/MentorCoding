using System;
namespace AirControlReservation;

public interface IStorage
{
    public Airplane Airplane { get; }

    public Task Save();
}


