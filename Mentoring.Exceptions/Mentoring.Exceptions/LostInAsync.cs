using System;
using System.Threading.Tasks;

namespace Mentoring.Exceptions
{
	class Program
	{
		static void Main(string[] args)
		{
			var lost = new Lost();
			//lost.RunVoid();
			//lost.RunTask();
			lost.RunTaskAndAwait();
			Console.Read();
		}
	}

	class Lost
	{
		public void RunVoid()
		{
			try
			{
				DoAsync(); //hmmmm, we haven't got any warnings here =(
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public void RunTask()
		{
			try
			{
				DoTaskAsync(); //there is a warning, but we like to ignore warnings >_<
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public async void RunTaskAndAwait()
		{
			try
			{
				await DoTaskAsync();//there is no warnings
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		async void DoAsync()
		{
			//just throw an exception
			await Task.Run(() => throw new Exception("You can't catch me!"));
		}
		public async Task DoTaskAsync()
		{
			await Task.Run(() => throw new Exception("You can't catch me!"));
		}
	}

}
