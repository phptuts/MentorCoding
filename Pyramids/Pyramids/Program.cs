// See https://aka.ms/new-console-template for more information
Console.Write("Enter a number: ");
var num = Convert.ToInt32(Console.ReadLine());

for (var i = 0; i <= num; i += 1)
{
    for (var j = 0; j <= i; j += 1)
    {
        Console.Write("*");
    }
    Console.Write("\n");
}
Console.WriteLine();
Console.WriteLine();
for (var i = 0; i <= num; i += 1)
{
    for (var j = num; j >= i; j -= 1)
    {
        Console.Write("*");
    }
    Console.Write("\n");
}
Console.WriteLine();
Console.WriteLine();
for (var i = num; i > 0; i -= 1)
{
    for (var j = num; j > 0; j -= 1)
    {
        if (j > i)
        {
            Console.Write(" ");
        }
        else
        {
            Console.Write("*");
        }
    }
    Console.Write("\n");
}
Console.WriteLine();
Console.WriteLine();
for (var i = num; i >= 0; i -= 1)
{
    for (var j = 0; j < num; j += 1)
    {
        if (j < i)
        {
            Console.Write(" ");
        }
        else
        {
            Console.Write("*");
        }
    }
    Console.Write("\n");
}


Console.ReadKey();