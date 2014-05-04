// -----------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace Euler.Tests.One
{
	using System;
	using System.Diagnostics;

	public class Program
	{
		public static void Main(string[] args)
		{
			Console.Title = "Problem One: Sum all multiples of 3 and 5 below 1000.";

			/*
			 * Problem One:
			 * 
			 * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
			 * Find the sum of all the multiples of 3 or 5 below 1000.
			 */

			Func<Int32, Boolean>[] conditions = { x => (x % 3) == 0, x => (x % 5) == 0 };
			Stopwatch watch;
			Boolean exit = false;
			do
			{
				Console.Write("Enter a starting value: ");
				String value = Console.ReadLine();

				Int32 startingValue;
				if (!Int32.TryParse(value, out startingValue))
				{
					Console.WriteLine("Bad argument given.");
					Console.ReadKey(true);
					return;
				}

				Console.Write("Enter a final value: ");
				value = Console.ReadLine();

				Int32 finalValue;
				if (!Int32.TryParse(value, out finalValue))
				{
					Console.WriteLine("Bad argument given.");
					Console.ReadKey(true);
					return;
				}
				
				watch = Stopwatch.StartNew();
				Console.WriteLine("Calculating sum...");

				Int32 sum = IntegerHelper.SumRange(startingValue, finalValue, conditions);

				watch.Stop();

				Console.WriteLine("Completed in {0:##.000}ms. Sum from {1} to {2} is {3}",
					watch.ElapsedMilliseconds,
					startingValue,
					finalValue,
					sum);
				
				Console.Write("Would you like to try again? [y/n] [default: y] ");
				value = Console.ReadLine();

				if (value != null && value.Equals("n", StringComparison.OrdinalIgnoreCase))
				{
					exit = true;
				}

				Console.Clear();
			} while (!exit);
		}
	}
}
