using System.Linq;
using System.Collections.Generic;
using JoeysShoppingList;





List<Item> shoppingList = new()
{
    new Item("bacon", 10.99, 1, StoreEnum.WoolWorths),
    new Item("eggs", 3.99, 1, StoreEnum.WoolWorths),
    new Item("cheese", 6.99, 1, StoreEnum.WoolWorths),
    new Item("chives", 1.00, 2, StoreEnum.CostCo),
    new Item("wine", 11.99, 6, StoreEnum.DanMurpys),
    new Item("brandy", 17.55, 6, StoreEnum.DanMurpys),
    new Item("bananas", 0.69, 3, StoreEnum.CostCo),
    new Item("ham", 2.69, 3, StoreEnum.CostCo),
    new Item("tomatoes", 3.26, 3, StoreEnum.CostCo),
    new Item("tissue", 8.45, 5, StoreEnum.CostCo),
};

List<ItemTotal> PrintSubTotal(List<Item> items)
{
    List<ItemTotal> itemTotals = items
        .Select(x => new ItemTotal(x.Name, x.UnitPrice, x.Quantity, x.Store, x.Quantity * x.UnitPrice))
        .ToList();
    itemTotals.ForEach(item =>
    {
        Console.WriteLine($"Name: {item.Name} | SubTotal: {item.Total:c}");
    });

    return itemTotals;
}

void GrandTotalReduce(List<ItemTotal> items)
{
    var total = items.Aggregate(0.0, (acc, item) =>
    {
        return acc + item.Total;
    });

    Console.WriteLine($"Total: {total:c}");
}

void PrintItemsInStore(List<Item> items, StoreEnum store)
{
    var storeItems = items.FindAll(x => x.Store == store).ToList();
    
    Console.WriteLine("Items: ");
    storeItems.OrderBy(x => x.Name).ToList().ForEach(item =>
    {
        Console.Write($"{item.Name}, ");
    });
    Console.WriteLine();
}

void PrintItemsByStore(List<Item> items)
{
    items.GroupBy(x => x.Store).ToList().ForEach(x =>
    {
        Console.WriteLine($"Store: {x.Key}");
        x.ToList().ForEach(item =>
        {
            Console.WriteLine($"    {item.Name}");
        });
    });
}

void PrintItemsAndOrderAlhpa(List<Item> items)
{
    items.OrderBy(item => item.Store.ToString()).ThenBy(item => item.Name).ToList().ForEach(i =>
    {
        Console.WriteLine($"Store: {i.Store} | Name: {i.Name}");
    });

}

void PrintItemsOverAPrice(List<Item> items, double cost)
{
    if (items.Exists(i => i.UnitPrice > cost))
    {
        Console.WriteLine($"Yes there are items over the cost: {cost:c}");
        return;
    }

    Console.WriteLine($"No items over the cost: {cost:c}");

}

Console.WriteLine("Print Sub Totals");
var newList = PrintSubTotal(shoppingList);
Console.WriteLine();
Console.WriteLine("Grand Total");
GrandTotalReduce(newList);
Console.WriteLine();
Console.WriteLine("Print Items in WoolWorths");
PrintItemsInStore(shoppingList, StoreEnum.WoolWorths);
Console.WriteLine();
Console.WriteLine("Group Items By Store and Print");
PrintItemsByStore(shoppingList);
Console.WriteLine();
Console.WriteLine("Items Over the cost 10.00");
PrintItemsOverAPrice(shoppingList, 10.00);
Console.WriteLine();
Console.WriteLine("Items Organized by store and alphetically");
PrintItemsAndOrderAlhpa(shoppingList);