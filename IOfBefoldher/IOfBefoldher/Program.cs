// See https://aka.ms/new-console-template for more information

Console.Write("Enter a number: ");

var num = Convert.ToInt32(Console.ReadLine());

var rows = num;
var isOdd = rows % 2 == 1;
var middleList = new List<int>();
if (isOdd)
{
    // Rounds up on the middle number so if it's 5 we'll get 2.5 which will turn into 3
    // Then we subtract one becuase of the zero index base.
    middleList.Add(Convert.ToInt32(Math.Ceiling(rows / 2.0)) - 1);
}
else
{
    // Divides the number of rows by 2 so if it's 6 we'll get 3
    // Subtracting one because it's zero index based.
    middleList.Add(rows / 2 - 1);
    middleList.Add(rows / 2);
}

for (var row = 0; row < rows; row += 1)
{
    for (var column = 0; column < rows; column += 1)
    {
        if (row == 0 || row  == rows - 1)
        {
            Console.Write("*");
        } else if (middleList.Contains(column))
        {
            Console.Write("*");
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.Write("\n");
    
}
Console.ReadKey();