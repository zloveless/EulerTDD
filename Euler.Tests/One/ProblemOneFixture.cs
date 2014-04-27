// -----------------------------------------------------------------------------
//  <copyright file="ProblemOneFixture.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace Euler.Tests.One
{
	using System;
	using System.Linq;
	using NUnit.Framework;

	[TestFixture]
	public class ProblemOneFixture
	{
		/*
		 * Problem One:
		 * 
		 * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
		 * Find the sum of all the multiples of 3 or 5 below 1000.
		 */

		[Test]
		public void IsMultipleOfThree_WhenGivenThree_ShouldReturnTrue()
		{
			const Int32 value = 3;
			Boolean actual    = IntegerHelper.IsMultipleOfThree(value);

			Assert.That(actual, Is.True);
		}

		[Test]
		public void IsMultipleOfThree_WhenGivenAMultipleOfThree_ShouldReturnTrue()
		{
			const Int32 value = 6;
			Boolean actual    = IntegerHelper.IsMultipleOfThree(value);

			Assert.That(actual, Is.True);
		}

		[Test]
		public void IsMultipleOfThree_WhenGivenNonMultipleOfThree_ShouldReturnFalse()
		{
			const Int32 value = 4;
			Boolean actual    = IntegerHelper.IsMultipleOfThree(value);

			Assert.That(actual, Is.False);
		}

		[Test]
		public void IsMultipleOfFive_WhenGivenMultipleOfFive_ShouldReturnTrue()
		{
			const Int32 value = 5;
			Boolean actual    = IntegerHelper.IsMultipleOfFive(value);

			Assert.That(actual, Is.True);
		}

		[Test]
		public void IsMultipleOfFive_WhenGivenNonMultipleOfFive_ShouldReturnFalse()
		{
			const Int32 value = 6;
			Boolean actual    = IntegerHelper.IsMultipleOfFive(value);

			Assert.That(actual, Is.False);
		}

		[Test]
		public void GetRange_WhenGivenAMinimumAndMaximumValue_ShouldReturnRangeOfIntegersBetweenValues()
		{
			const Int32 initial = 1;
			const Int32 maximum = 10;

			Int32[] values = {1, 2, 3, 4, 5, 6, 7, 8, 9};
			Int32[] actual = IntegerHelper.GetRange(initial, maximum).ToArray();

			Assert.That(actual, Is.Not.Empty);
			Assert.That(actual, Is.EqualTo(values));
		}

		[Test]
		public void GetRange_WhenGivenStartAndMaximumValueWithConditions_ShouldReturnRangeOfIntegersMatchingThoseConditions()
		{
			const Int32 initial = 1;
			const Int32 maximum = 10;

			Int32[] values                    = {3, 5, 6, 9};
			Func<Int32, Boolean>[] conditions = {IntegerHelper.IsMultipleOfThree, IntegerHelper.IsMultipleOfFive};

			Int32[] actual = IntegerHelper.GetRange(initial, maximum, conditions).ToArray();

			Assert.That(actual, Is.Not.Empty);
			Assert.That(actual, Is.EqualTo(values));
		}

		[Test]
		public void SumRange_ShouldSumGivenRange()
		{
			const Int32 initial  = 1;
			const Int32 maximum  = 10;
			const Int32 expected = 45;

			// Int32[] values = {1, 2, 3, 4, 5, 6, 7, 8, 9};
			Int32 actual   = IntegerHelper.SumRange(initial, maximum);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void SumRange_WithGivenConditions_ShouldReturnSumOfRange()
		{
			const Int32 initial  = 1;
			const Int32 maximum  = 10;
			const Int32 expected = 23;

			//Int32[] values = { 3, 5, 6, 9 };
			Func<Int32, Boolean>[] conditions = {IntegerHelper.IsMultipleOfThree, IntegerHelper.IsMultipleOfFive};
			Int32 actual = IntegerHelper.SumRange(initial, maximum, conditions);

			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
