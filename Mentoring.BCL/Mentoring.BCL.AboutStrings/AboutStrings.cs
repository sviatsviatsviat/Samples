using System;

namespace Mentoring.BCL.AboutStrings
{
	class Program
	{
		const string SC1 = "Const 1";
		const string SC2 = "Const 2";
		const string SC3 = "Const 3";

		static void Main(string[] args)
		{
			string s1 = SC1 + " " + SC2 + " " + SC3;
			Console.WriteLine(s1); //is it norm?

			string s2 = "I" + Environment.NewLine + "am" + Environment.NewLine + "splitted" + Environment.NewLine + "=(";
			Console.WriteLine(s2); //is it norm?

			string result = null;
			for (int i = 0; i < 100; i += 10)
			{
				result += "I like number " + i + Environment.NewLine; //is it norm?
			}
			Console.WriteLine(result);
			Console.Read();
		}
	}
}
