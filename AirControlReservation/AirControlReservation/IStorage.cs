using System;
namespace AirControlReservation;

public interface ISave
{
    public Airplane Airplane { get; }

    public Task Save();
}


