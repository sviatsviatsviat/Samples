using System;

namespace Mentoring.Samples.HalfLife
{
	//KISS -keep it simple stupid prinicple
	//imagine, how your function looks like, then make it simple lambda
	class Program
	{
		static void Main(string[] args)
		{
			
			Action<int> a = p => p++; 
			Action<string> b = p => Console.WriteLine(p);
			Action<string, int> c = (p, t) => Console.WriteLine("{0},{1}", p, t);
			Action<string> d = (string p) => Console.WriteLine(p); //try to transform it

			int num = 5;
			Func<int> e = () => num; //what is it

			Func<string, string> f = p => p.ToUpper();
			Func<string, string> g = (string p) => { return p.ToUpper(); };//try to transform it

			Action<A> h = (A p) => p.ToString();
			Action<B> i = h; //why?
		}

		class A
		{ }

		class B : A { }
	}
}
