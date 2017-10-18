using System;

namespace Mentoring.Samples.Extensions
{
	public static class SuperIntExtension
	{
		public static void SetZeroIfTwo(this int value)
		{ 
			if(value == 2) value = 0; 
		}
	}

	public static class SuperStringExtension
	{
		public static void IRemove(this string value)
		{
			Console.WriteLine("Trying to remove I...");
			value.Replace("I", "");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			int two = 2;
			two.SetZeroIfTwo();
			Console.WriteLine(two);

			string s = "IPhone";
			s.IRemove();
			Console.WriteLine(s);

			s = null;
			s.IRemove(); //will it be called?
			Console.WriteLine(s);

			Console.Read();
		}
	}
}
