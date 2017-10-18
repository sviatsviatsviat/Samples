using System;
using System.Collections.Generic;
using System.Linq;

namespace Mentoring.Samples.Boxing
{
	interface IPistol
	{
		void ChargeOne();
	}

	struct Pistol : IPistol
	{
		public int Ammo { get; private set; }

		public int Charge { get; private set; }

		public Pistol(int ammo)
		{
			Ammo = ammo;
			Charge = 0;
		}

		public void ChargeOne()
		{
			if(Ammo > 0)
			{
				Ammo--;
				Charge++;
			}
		}

		public override string ToString()
		{
			return $"Ammo: {Ammo}; Charged: {Charge}";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Pistol> arsenal = Enumerable.Repeat(new Pistol(10), 5).ToList();
			ChargeArsenal(arsenal);
			Console.WriteLine(String.Join("\r\n", arsenal));
			Console.Read();
		}

		static void ChargeArsenal(List<Pistol> arsenal)
		{
			foreach(Pistol item in arsenal)
			{
				item.ChargeOne();
			}

		}
	}
}
