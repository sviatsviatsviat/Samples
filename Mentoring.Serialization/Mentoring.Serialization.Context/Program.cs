using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mentoring.Serialization.Context
{
	[Serializable]
	class Data : ISerializable, IDisposable
	{
		FileStream m_file;

		public Data(string fileName)
		{
			m_file = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
		}

		protected Data(SerializationInfo info, StreamingContext context)
		{
			switch (context.State)
			{
				case StreamingContextStates.Clone:
					SafeFileHandle handle = new SafeFileHandle((IntPtr)info.GetValue("file", typeof(IntPtr)), true);
					m_file = new FileStream(handle, FileAccess.ReadWrite);
					break;
				default:
					m_file = new FileStream(info.GetString("fileName"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
					break;
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			switch(context.State)
			{
				case StreamingContextStates.Clone:
					info.AddValue("file", m_file.SafeFileHandle.DangerousGetHandle());
					break;
				default:
					info.AddValue("fileName", m_file.Name);
					break;
			}
		}

		public void Dispose()
		{
			try
			{
				m_file?.Dispose();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			BinaryFormatter bf = new BinaryFormatter();
			Data data = new Data("test.bin");
			using (MemoryStream ms = new MemoryStream())
			{
				//bf.Context = new StreamingContext(StreamingContextStates.Clone);
				bf.Serialize(ms, data);
				ms.Flush();
				ms.Seek(0, SeekOrigin.Begin);
				Data clone = bf.Deserialize(ms) as Data;
				data.Dispose();
				clone.Dispose();
				Console.WriteLine("Both objects are disposed");
			}
			Console.ReadKey();
		}		
	}
}
