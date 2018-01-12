using System;
using System.Runtime.InteropServices;

namespace Mentoring.BCL.MutableString
{
	[StructLayout(LayoutKind.Explicit)]
	struct MutableString
	{
		[FieldOffset(0)]
		public string String;
		[FieldOffset(0)]
		public char[] CharArray;
	}

	class Program
	{
		static void Main()
		{
			MutableString str = new MutableString();

			str.CharArray = "123".ToCharArray();
			Console.WriteLine(str.String);

			string before = str.String;

			str.CharArray[1] = '5';
			Console.WriteLine(str.String);
			string after = str.String;

			Console.WriteLine(Object.ReferenceEquals(before, after));
			Console.Read();
		}
	}

}
