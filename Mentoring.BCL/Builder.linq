<Query Kind="Statements" />

StringBuilder result = new StringBuilder();
for(int i = 0; i<9;i+=1)
{
	Console.WriteLine($"Builder capacity: {result.Capacity}, max capacity: {result.MaxCapacity}, length: {result.Length}");
	result.AppendLine($"I like number {i}");
}
Console.WriteLine($"Builder capacity: {result.Capacity}, max capacity: {result.MaxCapacity}, length: {result.Length}");

Console.Write(result.ToString());

//NOTE: tell about 4.5 and 4