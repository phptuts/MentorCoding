using System;
namespace JoeysShoppingList;

public class ItemTotal : Item
{
    public ItemTotal(string name, double unitPrice, int quantity, StoreEnum store, double total):
        base(name, unitPrice, quantity, store)
    {
        Total = total;
    }

    public double Total { get; }
}


