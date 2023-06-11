using System;
using AirControlReservation.Interfaces;
using AirControlReservation.Enums;
using AirControlReservation.Constants;

namespace AirControlReservation.Services
{
	public class AskSeatService: IAskSeatService
	{
		private IStorage _storage;

		public AskSeatService(IStorage storage)
		{
			_storage = storage;
		}

        public (ColumnLetter, int, bool) AskSeat(int rowStart, int numberOfRows)
        {
            Console.WriteLine();
            Console.Write("Please enter the row number: ");
            int.TryParse(Console.ReadLine(), out var rowNumber);
            while (rowNumber < rowStart || rowNumber > rowStart + numberOfRows)
            {
                Console.WriteLine("Invalid Entry! Please try again.");
                Console.Write("Please enter the row number: ");
                int.TryParse(Console.ReadLine(), out rowNumber);
            }

            Console.Write("Please enter the seat letter: ");
            var seatColumn = Console.ReadLine()?.FirstOrDefault() ?? ' ';

            while (!IsColumnSeatValid(seatColumn))
            {
                Console.WriteLine();
                Console.WriteLine(GeneralConstants.InvalidInputStr);
                Console.Write("Please enter the seat letter: ");

                seatColumn = Convert.ToChar(Console.ReadLine() ?? "");
            }
            var seatColumnEnum = GetColumnLetter(seatColumn);

            var seatTaken = _storage.Airplane.IsSeatTaken(rowNumber, seatColumnEnum);

            return (seatColumnEnum, rowNumber, seatTaken);
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
    }
}

