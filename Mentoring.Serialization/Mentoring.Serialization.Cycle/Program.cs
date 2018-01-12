using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Mentoring.Serialization.Cycle
{
	[Serializable]
	public class Data
	{

	}

	
	public class DataItem : Data
	{

	}

	class Program
	{
		static void Main(string[] args)
		{
			DataItem item = new DataItem();
			CheckXmlSerialization(item);
			CheckBinarySerialization(item);
			Console.ReadKey();
		}

		static void CheckXmlSerialization(DataItem data)
		{
			try
			{
				const string xmlFile = "defConstr.xml";
				using (FileStream fs = File.Open(xmlFile, FileMode.Create))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataItem));
					xmlSerializer.Serialize(fs, data);
					fs.Seek(0, SeekOrigin.Begin);
					data = xmlSerializer.Deserialize(fs) as DataItem;
					Console.WriteLine("XML deserialization {0}", data);
				}
				Process.Start("notepad.exe", xmlFile);
			}
			catch(Exception ex)
			{
				Console.WriteLine("XML serilaization {0}", ex.Message);
			}
		}

		static void CheckBinarySerialization(DataItem data)
		{
			try
			{
				const string binFile = "defConstr.bin";
				using (FileStream fs = File.Open(binFile, FileMode.Create))
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(fs, data);
					fs.Seek(0, SeekOrigin.Begin);
					data = bf.Deserialize(fs) as DataItem;
					Console.WriteLine("Binary deserialization {0}", data);
				}
				Process.Start("notepad.exe", binFile);
			}
			catch (SerializationException ex)
			{
				Console.WriteLine("Binary serilaization {0}", ex.Message);
			}
		}
	}
}
