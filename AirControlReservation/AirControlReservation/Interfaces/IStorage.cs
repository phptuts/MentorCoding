using System;
using AirControlReservation.Models;

namespace AirControlReservation.Interfaces;

public interface IStorage<TItem, TKey>
{
    public Task Create(TItem item);

    public Task<TItem?> Get(TKey id);

    public Task<List<TItem>> GetAll();

    public Task Update(TItem item);

    public Task Delete(TKey id);
}


