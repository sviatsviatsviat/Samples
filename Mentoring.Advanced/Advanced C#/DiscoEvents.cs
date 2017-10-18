using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.Samples.Delegates
{
	class Program
	{
		static Disco _disco = new Disco();
		static Action<object> Log;

		static void Main(string[] args)
		{
			Log = p => Console.WriteLine(p);

			_disco.SomethingHappens += LogDisco;
			for (int i = 0; i < 5; i++)
			{
				_disco.Next();
			}
			_disco.SomethingHappens -= LogDisco;
			Console.Read();
		}

		private static void LogDisco(object sender, Disco.DiscoEventArgs e)
		{
			Log(e.Type);
		}
	}

	enum DiscoEventType
	{
		Dance = 0,
		Drink = 1,
		Fight = 2,
		EverybodyDanceNow = 3
	}

	class Disco
	{
		public class DiscoEventArgs
		{
			public DiscoEventType Type { get; internal set; }
		}

		private Random _destiny = new Random();

		event EventHandler<DiscoEventArgs> _somethingHappens;
		public event EventHandler<DiscoEventArgs> SomethingHappens
		{
			add
			{
				_somethingHappens += value;
				Console.WriteLine("We got a new buddy");
			}
			remove
			{
				_somethingHappens -= value;
				Console.WriteLine("We lost somebody");
			}
		}

		public void Next()
		{
			int ev = _destiny.Next(4);
			OnSomethingHappened((DiscoEventType)ev);
		}

		void OnSomethingHappened(DiscoEventType type)
		{
			_somethingHappens?.Invoke(this, new DiscoEventArgs() { Type = type });
		}

	}
}
