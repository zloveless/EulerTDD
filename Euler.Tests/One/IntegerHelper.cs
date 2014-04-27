// -----------------------------------------------------------------------------
//  <copyright file="IntegerHelper.cs" company="Zack Loveless">
//      Copyright (c) Zack Loveless.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------

namespace Euler.Tests.One
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class IntegerHelper
	{
		public static Boolean IsMultipleOfThree(Int32 value)
		{
			return (value % 3) == 0;
		}

		public static Boolean IsMultipleOfFive(Int32 value)
		{
			return (value % 5) == 0;
		}

		public static IEnumerable<Int32> GetRange(Int32 minimum, Int32 maximum, params Func<Int32, Boolean>[] conditions)
		{
			IEnumerable<Int32> result = Enumerable.Range(minimum, maximum - 1);

			if (conditions != null && conditions.Length > 0)
			{
				return result.Where(a => conditions.Any(b => b.Invoke(a)));
			}

			return result;
		}

		public static Int32 SumRange(Int32 minimum, Int32 maximum, params Func<Int32, Boolean>[] conditions)
		{
			return GetRange(minimum, maximum, conditions).Sum();
		} 
	}
}
