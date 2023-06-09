﻿using System;
using AirControlReservation.Models;
using AirControlReservation.Enums;

namespace AirControlReservation.Factories;

public static class AirplaneFactory
{
	public static Airplane CreateAirplane(int numberOfRows = 40)
	{
        var rows = new Row[numberOfRows];

        for (var i = 0; i < numberOfRows; i += 1)
        {
            var row = new Row();
            var letterIndex = 0;
            foreach (ColumnLetter c in Enum.GetValues<ColumnLetter>())
            {
                row.Seats[letterIndex] = new Seat()
                {
                    Column = c,
                    Row = i + 1
                };
                letterIndex += 1;
            }
            rows[i] = row;
        }

        return new Airplane()
        {
            Rows = rows
        };
    }
}

