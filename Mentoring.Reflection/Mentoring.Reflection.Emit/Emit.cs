using System;
using System.Reflection.Emit;
using System.Reflection;

namespace Mentoring.Reflection.Emit
{
	class Emit
	{
		static void Main(string[] args)
		{
			AssemblyName asmName = new AssemblyName();
			asmName.Name = "SuperAssembly";
			asmName.Version = new Version("1.0.0.0");

			AssemblyBuilder asmBuilder = AssemblyBuilder.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
			ModuleBuilder moduleBuilder = asmBuilder.DefineDynamicModule("SuperAssembly");
			TypeBuilder typeBuilder = moduleBuilder.DefineType("SuperAssembly.InterestingType", TypeAttributes.Public);
			MethodBuilder method = typeBuilder.DefineMethod("SuperMethod", MethodAttributes.Public | MethodAttributes.Static);
			ILGenerator gen = method.GetILGenerator();
			gen.EmitWriteLine("Hello from dynamic!!!");
			gen.Emit(OpCodes.Ret);

			Type type = typeBuilder.CreateType();
			MethodInfo mi = type.GetMethod("SuperMethod");
			mi.Invoke(null, null);

			Console.Read();
		}
	}
}
