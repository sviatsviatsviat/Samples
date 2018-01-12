using Mentoring.Reflection.App;
using System;

namespace Mentoring.Reflection.AddIn
{
	
	public class SuperAddIn : AddInBase
	{
		public SuperAddIn()
		{
			AddInManager.SyncCache.Add("SuperAddIn record");
		}

		public override void Run()
		{
			AddInManager.SyncCache.Add("SuperAddIn record");
			Console.WriteLine("I'm working!!!!");
		}
	}
}
