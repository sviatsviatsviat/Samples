using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Mentoring.Serialization.DefConstructor
{
	[Serializable]
	public class Data
	{
		//what?
		public string Text { get; set; }

		protected int Count { get; set; }

		public Data()
		{
			Text = "Text";
			Count = 99;
		}

		public Data(string text, int count)
		{
			Text = text;
			Count = count;
		}

		[OnSerializing]
		public void OnSerializing(StreamingContext context)
		{
			Text = "AHAHAHA I'VE HACKED DATA";
		}

		public override string ToString()
		{
			return $"{Count}:{Text}";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Data data = new Data("Serialized text", 10);
			Console.WriteLine("Before serialization {0}", data);
			CheckXmlSerialization(data);
			CheckBinarySerialization(data);
			Console.ReadKey();
		}

		static void CheckXmlSerialization(Data data)
		{
			const string xmlFile = "defConstr.xml";
			using (FileStream fs = File.Open(xmlFile, FileMode.Create))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Data));
				xmlSerializer.Serialize(fs, data);
				fs.Seek(0, SeekOrigin.Begin);
				data = xmlSerializer.Deserialize(fs) as Data;
				Console.WriteLine("XML deserialization {0}", data);
			}
			Process.Start("notepad.exe", xmlFile);
		}

		static void CheckBinarySerialization(Data data)
		{
			const string binFile = "defConstr.bin";
			using (FileStream fs = File.Open(binFile, FileMode.Create))
			{
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(fs,data);
				fs.Seek(0, SeekOrigin.Begin);
				data = bf.Deserialize(fs) as Data;
				Console.WriteLine("Binary deserialization {0}", data);
			}
			Process.Start("notepad.exe", binFile);
		}
	}
}
