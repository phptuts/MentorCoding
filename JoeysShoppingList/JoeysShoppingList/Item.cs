using System;
namespace JoeysShoppingList;

class Item
{

    public Item(string name, double unitPrice, int quantity, StoreEnum store)
    {
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
        Store = store;
    }

    public string Name { get; }

    public double UnitPrice { get; }

    public int Quantity { get; }

    public StoreEnum Store { get; }

    public double SubTotal()
    {
        return UnitPrice * Quantity; ;
    }
}


