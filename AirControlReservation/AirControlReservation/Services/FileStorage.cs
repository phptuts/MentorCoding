using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AirControlReservation.Interfaces;
using AirControlReservation.Enums;
using AirControlReservation.Constants;
using AirControlReservation.Models;
using AirControlReservation.Factories;

namespace AirControlReservation.Services;

public class FileStorage : IStorage<Seat, string>
{
    public static readonly string FILE_NAME = "airplane.json";

    public readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    public async Task Create(Seat item)
    {
        var foundSeat = await Get(item.Id);
        if (foundSeat != null)
        {
            return;
        }
        var seats = await GetAll();
        seats.Add(item);
        await Save(seats);
    }

    public async Task<Seat?> Get(string id)
    {
        var seats = await GetAll();
        return seats.FirstOrDefault(x => x.Id == id);
    }

    public Task<List<Seat>> GetAll()
    {
        if (!File.Exists(FILE_NAME))
        {
            return Task.FromResult(new List<Seat>());
        }

        var text = File.ReadAllText(FILE_NAME);
        return Task.FromResult(JsonConvert.DeserializeObject<List<Seat>>(text, serializerSettings) ?? new List<Seat>());
    }

    public async Task Update(Seat item)
    {
        var seats = await GetAll();
        var updatedSeats = seats.Where(x => x.Id != item.Id).ToList();
        updatedSeats.Add(item);
        await Save(updatedSeats);
    }

    public async Task Delete(string id)
    {
        var seats = await GetAll();
        var updatedSeats = seats.Where(x => x.Id != id).ToList();
        await Save(updatedSeats);
    }

    private async Task Save(List<Seat> seats)
    {
        if (File.Exists(FILE_NAME))
        {
            File.Delete(FILE_NAME);
        }

        var json = JsonConvert.SerializeObject(seats, serializerSettings);
        await File.WriteAllTextAsync(FILE_NAME, json);

        return;
    }
}

