using System;
namespace AirControlReservation;

public static class Print
{
	public static void PrintStartMenu()
	{
		Console.Write(@"
*******************************
**    Welcome to AirConsole  **
*******************************
Task Selection
R: Reservation
S: Seat Verification
X: Exit the System
Please enter the task you want to perform: ");
	}
    public static void PrintBusinessClass(Airplane airplane)
    {
        Console.WriteLine(@"
*******************************
**       Business Class      **
*******************************
    A B C D E");
        
        for (var i = 0; i < 5; i += 1)
        {
            Console.Write($"  {i + 1} ");
            foreach (var seat in airplane.Rows[i].Seats)
            {
                Console.Write(seat.Taken() ? "X" : " ");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public static void PrintEcomonyClass(Airplane airplane)
    {
        Console.WriteLine(@"
*******************************
**       Business Class      **
*******************************
     A B C D E");

        for (var i = 5; i < airplane.Rows.Length; i += 1)
        {
            Console.Write($"  {i + 1} ");
            if (i + 1 < 10)
            {
                Console.Write(" ");
            }
            foreach (var seat in airplane.Rows[i].Seats)
            {
                Console.Write(seat.Taken() ? "X" : " ");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}

