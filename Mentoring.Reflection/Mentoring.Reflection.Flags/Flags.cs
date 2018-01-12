using System;

namespace Mentoring.Reflection.Flags
{
	class Program
	{
		[Flags]
		enum Ideal : byte
		{
			Beatiful = 1,
			Smart = 2,
			Strong = 4,
			Rich = 8
		}

		static void Main(string[] args)
		{
			Ideal ideal = Ideal.Smart | Ideal.Strong;
			Console.WriteLine(ideal);
			ideal = Ideal.Beatiful | Ideal.Smart;
			Console.WriteLine(ideal);
			Console.Read();
		}
	}
}
