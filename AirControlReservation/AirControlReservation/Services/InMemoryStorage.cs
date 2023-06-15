using System;
using AirControlReservation.Interfaces;
using AirControlReservation.Models;
using AirControlReservation.Factories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirControlReservation.Services;


public class InMemoryStorage : IStorage<Seat, string>
{
    private List<Seat> Seats = new List<Seat>();

    public async Task Create(Seat item)
    {
        var foundSeat = await Get(item.Id);
        if (foundSeat != null)
        {
            return;
        }
        var seats = await GetAll();
        Seats.Add(item);
    }

    public async Task Delete(string id)
    {
        var seats = await GetAll();
        Seats = seats.Where(x => x.Id != id).ToList();
    }

    public Task<Seat?> Get(string id)
    {
        return Task.FromResult(Seats.FirstOrDefault(x => x.Id == id));
    }

    public Task<List<Seat>> GetAll()
    {
        return Task.FromResult(Seats);
    }

    public async Task Update(Seat item)
    {
        var seats = await GetAll();
        var updatedSeats = seats.Where(x => x.Id != item.Id).ToList();
        updatedSeats.Add(item);
        Seats = updatedSeats;
    }
}

