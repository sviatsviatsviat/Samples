using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace Mentoring.Reflection.SweetDom
{
	class Program
	{
		static void Main(string[] args)
		{
			var provider = new CSharpCodeProvider();
			Console.Write("Put code here: ");
			string codeCommand = Console.ReadLine();

			CompilerParameters compilerOptions = new CompilerParameters();
			compilerOptions.GenerateInMemory = true;

			string executableWrapped = $"using System; namespace Mentoring.Reflection.SweetDom{{public class Executor{{public void Execute(){{{codeCommand};}}}}}}";

			CompilerResults compRes = provider.CompileAssemblyFromSource(compilerOptions, executableWrapped);
			Assembly asm = compRes.CompiledAssembly;
			Type type = asm.GetType("Mentoring.Reflection.SweetDom.Executor");
			var executor = Activator.CreateInstance(type);
			MethodInfo execute = type.GetMethod("Execute");
			execute.Invoke(executor, null);

			Console.Read();
		}
	}
}
