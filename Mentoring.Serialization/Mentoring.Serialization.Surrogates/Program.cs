using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mentoring.Serialization.Surrogates
{
	class Data
	{
		public string Path { get; set; }
	}

	class FilePathSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			string path = ((Data)obj).Path;
			if (context.State == StreamingContextStates.CrossMachine || context.State == StreamingContextStates.Remoting)
			{
				info.AddValue("MachineName", Environment.MachineName);
				Console.WriteLine("Send message");
			}
			info.AddValue("String", path);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			string path = info.GetString("String");
			Data data = (Data)obj;
			data.Path = path;
			if (context.State == StreamingContextStates.CrossMachine || context.State == StreamingContextStates.Remoting)
			{
				Console.WriteLine($"Recived message from {info.GetString("MachineName")}");
			}
			return data;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			const string fName = "test.bin";

			BinaryFormatter bf = new BinaryFormatter();
			SurrogateSelector ss = new SurrogateSelector();
			bf.Context = new StreamingContext(StreamingContextStates.CrossMachine);
			ss.AddSurrogate(typeof(Data), bf.Context, new FilePathSurrogate());
			bf.SurrogateSelector = ss;

			using (FileStream fs = new FileStream(fName, FileMode.Create))
			{
				Data data = new Data() { Path = "Dir\\File.txt" };
				Console.WriteLine(data.Path);
				bf.Serialize(fs, data);
				fs.Flush();
				fs.Seek(0, SeekOrigin.Begin);
				data = (Data)bf.Deserialize(fs);
				Console.WriteLine(data.Path);
			}
			Process.Start("notepad.exe", fName);
			Console.ReadKey();
		}
	}
}
