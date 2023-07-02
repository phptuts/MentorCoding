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

void PrintSubTotal(List<Item> items)
{
    items.ForEach(item =>
    {
        Console.WriteLine($"Name: {item.Name} | SubTotal: {item.SubTotal():c}");
    });
}

void GrandTotalReduce(List<Item> items)
{
    var total = items.Aggregate(0.0, (acc, item) =>
    {
        return acc + item.SubTotal();
    });

    Console.WriteLine($"Total: {total:c}");
}

void PrintItemsInStore(List<Item> items, StoreEnum store)
{
    var storeItems = items.FindAll(x => x.Store == store).ToList();
    storeItems.Sort((itemA, itemB) => string.Compare(itemA.Name, itemB.Name));
    Console.WriteLine("Items: ");
    storeItems.ForEach(item =>
    {
        Console.Write($"{item.Name}, ");
    });
    Console.WriteLine();
}

void PrintItemsByStore(List<Item> items)
{
    var listByStore =items.Aggregate(new Dictionary<StoreEnum, List<Item>>(), (acc, item) =>
    {
        if (acc.ContainsKey(item.Store))
        {
            acc[item.Store].Add(item);
        }
        else
        {
            acc[item.Store] = new List<Item>()
            {
                item
            };
        }

        return acc;
    });

    listByStore.AsEnumerable().ToList().ForEach(storeList =>
    {
        Console.WriteLine($"Store: {storeList.Key}");
        storeList.Value.ForEach(item =>
        {
            Console.WriteLine($"    {item.Name}");
        });
    });

}

void PrintItemsAndOrderAlhpa(List<Item> items)
{
    var byStore = items.Aggregate(new Dictionary<StoreEnum, List<Item>>(), (acc, item) =>
    {
        if (acc.ContainsKey(item.Store))
        {
            acc[item.Store].Add(item);
        }
        else
        {
            acc[item.Store] = new List<Item>()
            {
                item
            };
        }

        return acc;
    });

    var listByStore = byStore.AsEnumerable().ToList();
    listByStore.Sort((a, b) => string.Compare(a.ToString(), b.ToString()));
    listByStore.ForEach(storeList =>
    {
        Console.WriteLine($"Store: {storeList.Key}");
        var items = storeList.Value;
        items.Sort((a, b) => string.Compare(a.Name, b.Name));
        storeList.Value.ForEach(item =>
        {
            Console.WriteLine($"    {item.Name}");
        });
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
PrintSubTotal(shoppingList);
Console.WriteLine();
Console.WriteLine("Grand Total");
GrandTotalReduce(shoppingList);
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