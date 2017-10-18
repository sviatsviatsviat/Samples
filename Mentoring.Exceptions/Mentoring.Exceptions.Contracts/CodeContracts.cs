using System;
using System.Diagnostics.Contracts;

namespace Mentoring.Exceptions.Contracts
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Hobbit frodo = new Hobbit(30);
				frodo.TakeARing(false);
				Hobbit bilbo = new Hobbit(200);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.Read();
		}
	}

	class Hobbit
	{
		public int Age { get; set; }

		private bool m_visible = true;
		public bool Visible
		{
			get
			{
				return m_visible;
			}
			set
			{
				m_visible = true;
			}
		}


		public Hobbit(int age)
		{
			Contract.Requires<ArgumentOutOfRangeException>(age >= 0, "Is it hobbit from the past?");
			Age = age;
			Visible = true;
		}

		public void TakeARing(bool simpleRing)
		{
			Contract.Ensures(simpleRing == Visible);
			Visible = simpleRing;	
		}

		[ContractInvariantMethod]
		void MustHobbitDie()
		{
			Contract.Invariant(Age < 150, "This hobbit is too old");
		}
	}

	
}
