using System;

namespace AirControlReservation;

public class SaveMemory : ISave
{
    private Airplane? _airplane;

    public Airplane Airplane
    {
        get
        {
            if (_airplane is null)
            {
                var airplane = AirplaneFactory.CreateAirplane();
                Save(airplane);
                return airplane;
            }

            return _airplane;
        }
        private set
        {
            _airplane = value;
        }
    }

    public Task Save(Airplane airplane)
    {
        Airplane = airplane;
        return Task.CompletedTask;
    }
}

