using System;
using AirControlReservation.Interfaces;
using AirControlReservation.Enums;
using AirControlReservation.Constants;
using AirControlReservation.Models;

namespace AirControlReservation.Services
{
	public class SeatSelector : ISeatSelector
	{
		private IStorage<Seat, string> _storage;

		public SeatSelector(IStorage<Seat, string> storage)
		{
			_storage = storage;
		}

        public async Task<Seat> AskSeat(int rowStart, int numberOfRows)
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

            var seat = await _storage.Get($"{rowNumber}{seatColumnEnum}");

            return seat ?? new Seat()
            {
                Column = seatColumnEnum,
                Row = rowNumber
            };
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

