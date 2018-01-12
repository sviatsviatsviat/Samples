using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace Mentoring.Reflection.Simple
{
	class Foo
	{
		private string _name;

		public string  Name
		{
			get
			{
				return _name;
			}
		}

		public Foo()
		{
			_name = "Foo";
		}
		public Foo(string name)
		{
			_name = name;
		}

		private string DoFoo(string value)
		{
			return new String(value?.Where(p => _name.Contains(p)).ToArray());
		}
	}

	class Program
	{
		static Func<string, string> DoFoo = null;

		static void Main(string[] args)
		{
			Foo foo = new Foo();
			Type ti = typeof(Foo);

			FieldInfo fi = ti.GetField("_name", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic);
			Console.WriteLine($"Field value: {fi.GetValue(foo)}");
			Console.WriteLine($"Property value: {foo.Name}");
			fi.SetValue(foo, "Food");
			Console.WriteLine($"Property value: { foo.Name}");

			MethodInfo mi = ti.GetMethod("DoFoo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
			Console.WriteLine($"DoFoo method: {mi.Invoke(foo, new object[] { "Floor" })}");

			DoFoo = (Func<string,string>)Delegate.CreateDelegate(typeof(Func<string,string>),foo,mi);
			Console.WriteLine($"DoFoo delegate: {DoFoo("Floor")}");

			Console.Read();
		}
	}
}
