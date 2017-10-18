using System;
using System.Collections.Generic;

namespace Mentoring.Exceptions.WarmUp
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				MiddleEarth md = new MiddleEarth();
				Console.WriteLine(md.GetPersonDescription("Jon Snow"));
			}
			catch(MordorException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.Read();
		}
	}

	class MiddleEarth
	{
		private Dictionary<string, string> m_persons = new Dictionary<string, string>()
		{
			{ "Frodo", "He is 50 years old" },
			{ "Gandalf", "You shall not path"}
		};

		public string GetPersonDescription(string name)
		{
			try
			{
				return m_persons[name];
			}
#if MORDORLOSE
			catch(KeyNotFoundException ex)
			{
				throw new MordorException("This is not a person from Middle Earth", ex);
			}
#endif
			catch(Exception ex)
			{
				throw ex; //is it good?
			}
		}
	}

	[Serializable]
	class MordorException : Exception
	{
		public MordorException(string message, Exception innerException) 
			: base(message, innerException) { }

	}
}
