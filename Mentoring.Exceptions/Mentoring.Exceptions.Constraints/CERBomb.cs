using System;
#if CHECKBOMB
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
#endif

namespace Mentoring.Exceptions.Constraints
{
	class Program
	{
		static void Main(string[] args)
		{
#if CHECKBOMB
			RuntimeHelpers.PrepareConstrainedRegions();
#endif
			try
			{
				Console.WriteLine("Prepare bomb");
				Console.Read();
			}
			finally
			{
				Bomb.Boom();
			}
			Console.Read();
		}
	}

	static class Bomb
	{
		static Bomb()
		{
			throw new Exception("Not enough gunpowder");
		}

#if CHECKBOMB
		[ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
#endif
		public static void Boom()
		{
			Console.WriteLine("Boom");
		}
	}
}
