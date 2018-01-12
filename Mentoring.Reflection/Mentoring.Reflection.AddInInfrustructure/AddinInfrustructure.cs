using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mentoring.Reflection.App
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class AddInAttribute : Attribute
	{
		public Type Entry { get; }

		public string Name { get; }

		public AddInAttribute(string name, Type entry)
		{
			Name = name;
			Entry = entry;
		}
	}

	public interface IAddIn
	{
		void Run();
	}

	public abstract class AddInBase : MarshalByRefObject, IAddIn
	{
		public abstract void Run();
	}

	public class AddInManager
	{
		public static List<string> SyncCache = new List<string>();

		public IAddIn LoadAddIn(string assemblyString)
		{
			IAddIn addIn = null;
			Guid guid = Guid.NewGuid();
			AppDomain addInDomain = AppDomain.CreateDomain(guid.ToString());
			try
			{
				Assembly asm = addInDomain.Load(assemblyString);
				AddInAttribute attr = asm.GetCustomAttribute<AddInAttribute>();
				if (attr == null)
				{
					AppDomain.Unload(addInDomain);
				}
				else
				{
					addIn = (IAddIn)addInDomain.CreateInstanceAndUnwrap(asm.FullName, attr.Entry.FullName);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				AppDomain.Unload(addInDomain);
				throw;
			}
			return addIn;
		}
	}
}