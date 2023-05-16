// See https://aka.ms/new-console-template for more information

Console.Write("Enter a number: ");

var size = Convert.ToInt32(Console.ReadLine());

List<int> GetIndexListForStarsOfMiddlePartOfI(int size)
{
    var isOdd = size % 2 == 1;
    var indexListForColumnOftheI = new List<int>();
    if (isOdd)
    {
        // Rounds up on the middle number so if it's 5 we'll get 2.5 which will turn into 3
        // Then we subtract one becuase of the zero index base.
        indexListForColumnOftheI.Add(Convert.ToInt32(Math.Ceiling(size / 2.0)) - 1);
    }
    else
    {
        // Divides the number of size by 2 so if it's 6 we'll get 3
        // Subtracting one because it's zero index based.
        indexListForColumnOftheI.Add(size / 2 - 1);
        indexListForColumnOftheI.Add(size / 2);
    }

    return indexListForColumnOftheI;
}

// This is a list of indexes that should be stared for the middle part of the I.
List<int> columnsIndexThatShouldBeStarred = GetIndexListForStarsOfMiddlePartOfI(size);

bool IsTopOrBottomOfI(int row)
{
    return row == 0 || row == size - 1;
}


for (var row = 0; row < size; row += 1)
{
    for (var column = 0; column < size; column += 1)
    {
        // If it's on the top or bottom of the I it should be stared no matter what.
        if (IsTopOrBottomOfI(row))
        {
            Console.Write("*");
        }
        else if (columnsIndexThatShouldBeStarred.Contains(column))
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