using System;
using Mentoring.Samples.Enums;

namespace Mentoring.Samples.TrafficLight
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach(TrafficLightState item in Enum.GetValues(typeof(TrafficLightState)))
			{
				switch(item)
				{
					case TrafficLightState.Green:
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("This is green");
						break;
					case TrafficLightState.Red:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("This is red");
						break;
					case TrafficLightState.Yellow:
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("This is yellow");
						break;
					default:
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
						Console.Write("D");
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("I");
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.Write("S");
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("C");
						Console.ForegroundColor = ConsoleColor.DarkRed;
						Console.WriteLine("O");
						break;
				}
			}
			Console.ReadLine();
		}
	}
}
