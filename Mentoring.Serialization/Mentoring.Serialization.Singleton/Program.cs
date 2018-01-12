using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.Serialization.Singleton
{

#if CUSTOM
	[Serializable]
	class Storage : List<string>, ISerializable
	{
		public static Storage Instance;

		static Storage()
		{
			Instance = new Storage();
		}

		private Storage():base()
		{

		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.SetType(typeof(StorageSerializationRef));
		}

		[Serializable]
		class StorageSerializationRef : IObjectReference
		{
			public object GetRealObject(StreamingContext context)
			{
				return Instance;
			}
		}
	}
#else
	[Serializable]
	class Storage : List<string>
	{
		public static Storage Instance;

		static Storage()
		{
			Instance = new Storage();
		}

		private Storage():base()
		{

		}
	}
#endif

	[Serializable]
	class Data
	{
		public string Text { get; set; }

		public Storage Storage { get; set; }

		public Data(string text)
		{
			Text = text;
			Storage = Storage.Instance;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Text);
			foreach(string line in Storage)
			{
				sb.AppendLine(line);
			}
			return sb.ToString();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			const string filePath = "data.bin";
			if(!File.Exists(filePath)) //first run
			{
				Storage.Instance.Add("First Run Test");
				Data data = new Data("Text");
				Console.WriteLine(data);
				using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(fs, data);
				}
			}
			else //second run
			{
				Storage.Instance.Add("Second Run Test");
				using (FileStream fs = new FileStream(filePath, FileMode.Open))
				{
					BinaryFormatter bf = new BinaryFormatter();
					Data data = bf.Deserialize(fs) as Data;
					Console.WriteLine(data);
					Storage.Instance.Add("One more record");
					Console.WriteLine(data);
				}
				File.Delete(filePath);
			}
			Console.ReadKey();
		}
	}
}
