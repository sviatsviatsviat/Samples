using System;

namespace Mentoring.Reflection.App
{
	class Program
	{
		static void Main(string[] args)
		{
			AddInManager.SyncCache.Add("App record");
			AddInManager manager = new AddInManager();
			IAddIn addIn = manager.LoadAddIn("Mentoring.Reflection.AddIn");
			addIn.Run();

			foreach (var item in AddInManager.SyncCache)
			{
				Console.WriteLine(item);
			}

			Console.Read();
		}
	}
}
