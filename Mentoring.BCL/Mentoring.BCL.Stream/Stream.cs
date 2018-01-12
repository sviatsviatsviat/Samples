using System;
using System.IO;
using System.Text;

namespace Mentoring.BCL.FastStream
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.Unicode;
			string input = "Hello\u040e";

			Console.WriteLine(input);

			using (Stream str = Console.OpenStandardOutput())
			{
				using (Stream bs = new BufferedStream(str, 8))
				{
					bs.Write(Encoding.Unicode.GetBytes(input), 0, input.Length);
					bs.Flush();
					Console.Read();
				}
			}
			Console.Read();
		}
	}
}
