using System;
using System.Text;

namespace Mentoring.BCL.Builder
{
	class Program
	{
		static void Main(string[] args)
		{
			StringBuilder result = new StringBuilder(16,150);
			for (int i = 0; i < 9; i += 1)
			{
				Console.WriteLine($"Builder capacity: {result.Capacity}, max capacity: {result.MaxCapacity}, length: {result.Length}");
				result.AppendLine($"I like number {i}");
			}
			Console.WriteLine($"Builder capacity: {result.Capacity}, max capacity: {result.MaxCapacity}, length: {result.Length}");

			Console.Write(result.ToString());
			Console.Read();
			//NOTE: tell about 4.5 and 4
		}
	}
}
