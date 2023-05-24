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



		Start();
    }

	public void SeatVerification()
	{
		Console.WriteLine("Not Implemented");

		Start();
	}
}

