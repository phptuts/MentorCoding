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
			Console.Write("Please enter the row number: ");
			int rowNumber;
            int.TryParse(Console.ReadLine(), out rowNumber);
            while (!IsValidRowSeatClass(seatClass, rowNumber))
            {
                Console.WriteLine();
                Console.WriteLine(InvalidEntry);
                Console.Write("Please enter the row number: ");
                rowNumber = Convert.ToInt32(Console.ReadLine());
            }
			Console.Write("Please enter the seat letter: ");
            var seatColumn = Convert.ToChar(Console.Read());

            while (!IsColumnSeatValid(seatColumn))
            {
                Console.WriteLine();
                Console.WriteLine(InvalidEntry);
                Console.Write("Please enter the seat letter: ");

                seatColumn = Convert.ToChar(Console.Read());
            }
			var seatColumnEnum = GetColumnLetter(seatColumn);
			findingSeat = IsSeatTaken(rowNumber, seatColumnEnum);

			if (findingSeat)
			{
				Console.WriteLine($"Sorry seat {rowNumber}{seatColumn} is already taken.");
				Console.WriteLine();
                continue;
			}

			Console.WriteLine($"Seat {rowNumber}{seatColumn} is available.");
			Console.Write("Please enter the passenger's firstname: ");
			var firstName = Console.ReadLine();
			Console.Write("Please enter the passenger's lastname: ");
			var lastName = Console.ReadLine();
			Console.Write("Please enter the passenger's passport number: ");
			var passPortNumber = Console.ReadLine();
            Console.WriteLine($"Seat {rowNumber}{seatColumn} is was successfully booked.");
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

	public bool IsValidRowSeatClass(char seatClass, int rowNumber)
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

	public bool IsColumnSeatValid(char seatColunm)
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

	public ColumnLetter GetColumnLetter(char seatColunm)
	{
        ColumnLetter columnLetter;
        if (!Enum.TryParse(seatColunm.ToString(), false, out columnLetter))
        {
            throw new Exception("Invalid Seat Column");
        }

		return columnLetter;
    }

    public bool IsSeatTaken(int rowNumber, ColumnLetter seatColunm)
	{
		return _saver.Airplane.IsSeatTake(rowNumber, seatColunm);
	}

	public void SeatVerification()
	{
		Console.WriteLine("Not Implemented");

		Start();
	}
}

