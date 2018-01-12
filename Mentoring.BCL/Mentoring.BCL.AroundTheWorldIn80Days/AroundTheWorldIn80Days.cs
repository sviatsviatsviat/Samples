using System;

namespace Mentoring.BCL.AroundTheWorldIn80Days
{
	class AroundTheWorldIn80Days
	{
		static void Main(string[] args)
		{
			//My current time zone is +03:00
			//Let's imagine we got this text data
			string dataFromTextFile = "31.10.2017 17:07:10 +02:00";

			DateTime dt = DateTime.Parse(dataFromTextFile);
			Console.WriteLine(dt); //??

			DateTimeOffset dto = DateTimeOffset.Parse(dataFromTextFile);
			Console.WriteLine(dto);//??
			Console.WriteLine(dto.LocalDateTime);

			Console.Read();
		}
	}
}
