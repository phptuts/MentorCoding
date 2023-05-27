using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AirControlReservation;

public class AirControl
{
	private ISave _saver;

    private readonly List<char> ValidStartOptions = new List<char> { 'X', 'R', 'S' };
    private readonly List<char> ValidSeatOptions = new List<char> { 'E', 'B' };
    private readonly string InvalidEntry = "Invalid Entry! Please try again.";


    public AirControl(ISave saver)
	{
		_saver = saver;
	}

	public void Start()
	{
		Print.PrintStartMenu();
		var menuOption = Console.ReadKey();
		while(!ValidStartOptions.Contains(menuOption.KeyChar))
        {
			Console.WriteLine();
            Console.WriteLine(InvalidEntry);
			Console.Write("Please enter the task you want to perform: ");
			menuOption = Console.ReadKey();

        }
        switch(menuOption.KeyChar)
        {
			case 'S':
				SeatVerification();
				break;
			case 'R':
				Reserveration();
				break;
			default:
				Console.WriteLine();
				Console.WriteLine("Good Bye!");
				break;
		}
	}

	public void Reserveration()
	{
		Console.WriteLine(@"
*******************************
**         Seat Class        **
*******************************
Seat Class Selection:
B: Business Class
E: Economy Class
");
		Console.Write("Please enter the seat class you want to reserve: ");
		var seatClass = Console.ReadKey().KeyChar;
        while (!ValidSeatOptions.Contains(seatClass))
        {
            Console.WriteLine();
            Console.WriteLine(InvalidEntry);
            Console.Write("Please enter the seat class you want to reserve: ");
			seatClass = Console.ReadKey().KeyChar;
        }
		if (seatClass == 'B')
		{
			Print.PrintBusinessClass(_saver.Airplane);
		}
		else
		{
			Print.PrintEcomonyClass(_saver.Airplane);
		}
		var findingSeat = true;

		while(findingSeat)
		{
			(int rowNumber, ColumnLetter seatColumnEnum) = AskForSeat(seatClass);
			findingSeat = IsSeatTaken(rowNumber, seatColumnEnum);

			if (findingSeat)
			{
				Console.WriteLine($"Sorry seat {rowNumber}{seatColumnEnum} is already taken.");
				Console.WriteLine();
                continue;
			}

			Console.WriteLine($"Seat {rowNumber}{seatColumnEnum} is available.");
			Console.Write("Please enter the passenger's firstname: ");
			var firstName = Console.ReadLine();
			Console.Write("Please enter the passenger's lastname: ");
			var lastName = Console.ReadLine();
			Console.Write("Please enter the passenger's passport number: ");
			var passPortNumber = Console.ReadLine();
            Console.WriteLine($"Seat {rowNumber}{seatColumnEnum} is was successfully booked.");
			_saver.Airplane.Book(rowNumber, seatColumnEnum, new Passenger()
			{
				FirstName = firstName ?? "",
				LastName = lastName ?? "",
				PassPortNumber = passPortNumber ?? ""
			});
			_saver.Save();
        }



        Start();
    }

	private (int, ColumnLetter) AskForSeat(char? seatClass = null)
	{
        Console.Write("Please enter the row number: ");
        _ = int.TryParse(Console.ReadLine(), out int rowNumber);
		var defaultSeatClass = rowNumber <= 5 ? 'B' : 'E';
		
        while (!IsValidRowSeatClass(seatClass ?? defaultSeatClass, rowNumber))
        {
            Console.WriteLine();
            Console.WriteLine(InvalidEntry);
            Console.Write("Please enter the row number: ");
            rowNumber = Convert.ToInt32(Console.ReadLine());
        }
        Console.Write("Please enter the seat letter: ");
        var seatColumn = Convert.ToChar(Console.ReadLine() ?? "");

        while (!IsColumnSeatValid(seatColumn))
        {
            Console.WriteLine();
            Console.WriteLine(InvalidEntry);
            Console.Write("Please enter the seat letter: ");

            seatColumn = Convert.ToChar(Console.ReadLine() ?? "");
        }
        var seatColumnEnum = GetColumnLetter(seatColumn);

		return (rowNumber, seatColumnEnum);
    }

    private bool IsValidRowSeatClass(char seatClass, int rowNumber)
	{
		if (rowNumber <= 0)
		{
			return false;
		}

		if (seatClass == 'B')
		{
			return rowNumber <= 5;
		}

		return rowNumber >= 5 && rowNumber <= 40;
	}

    private bool IsColumnSeatValid(char seatColunm)
	{
       try
	   {
			GetColumnLetter(seatColunm);
			return true;
		}
		catch (Exception)
        {
			return false;
		}
    }

    private ColumnLetter GetColumnLetter(char seatColunm)
	{
        ColumnLetter columnLetter;
        if (!Enum.TryParse(seatColunm.ToString(), false, out columnLetter))
        {
            throw new Exception("Invalid Seat Column");
        }

		return columnLetter;
    }

    private bool IsSeatTaken(int rowNumber, ColumnLetter seatColunm)
	{
		return _saver.Airplane.IsSeatTaken(rowNumber, seatColunm);
	}

    private void SeatVerification()
	{
        Console.WriteLine();
        (int rowNumber, ColumnLetter seatColumnEnum) = AskForSeat();

		if (!_saver.Airplane.IsSeatTaken(rowNumber, seatColumnEnum))
		{
			Console.WriteLine("This seat is available.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Start();
            return;
		}

		var passenger = _saver.Airplane.GetPassenger(rowNumber, seatColumnEnum);
		Console.Write($@"Passenger details
Firstname: {passenger?.FirstName}
Lastname: {passenger?.LastName}
Passport Number: {passenger?.PassPortNumber}
");

		Console.WriteLine("Press any key to continue...");
		Console.ReadKey();

        Start();
	}
}

