using System;

namespace Mentoring.BCL.Intern
{
	/*
	 *	To intern your string use String.Intern method  
	 *	To check if your string has been interned use String.IsInterned method
	 *	Use [assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)] to disable interning (but currently it's not working)
	*/
	class Program
	{
		static void Main(string[] args)
		{
			string s1 = "I'm a unique string";
			string s2 = "I'm a unique string";		
			CompareStringRefs(s1, s2);//what? why????

			Console.Write("Input something: ");
			string s3 = Console.ReadLine();//input: I'm a unique string
			CompareStringRefs(s1, s3); //what? why???

			string intern = String.IsInterned(s3);
			if(intern==null)
			{
				Console.WriteLine($"Input isn't interned!");
			}
			else
			{
				Console.WriteLine($"Input is interned!");
			}
			CompareStringRefs(intern, s1); //what?? why?? Oo

			Console.Read();
		}

		static void CompareStringRefs(string s1, string s2)
		{
			Console.WriteLine(Object.ReferenceEquals(s1, s2) ? "Refs are the same" : "Refs are different");
		}
	}
}
