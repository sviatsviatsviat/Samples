using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mentoring.BCL.BoringCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			var GetQueueCapacity = GetQueueCapacityFunc<int>();
			var GetStackCapacity = GetStackCapacityFunc<int>();
			var GetDictCapacity = GetDictionaryCapacityFunc<int, int>();

			List<int> list = new List<int>(5);
			Queue<int> queue = new Queue<int>(6);
			Stack<int> stack = new Stack<int>(10);
			Dictionary<int, int> dict = new Dictionary<int, int>(4);

			Console.WriteLine($"{"i",2}|{"List",6}|{"Stack",6}|{"Queue",6}|{"Dict.Buck.",10}|{"Dict.Entr.",10}|");
			for (int i = 0; i < 9; i++)
			{
				list.Add(i);
				queue.Enqueue(i);
				stack.Push(i);
				dict.Add(i, i * 100);
				var dictCap = GetDictCapacity(dict);
				Console.WriteLine($"{i,2}|{list.Capacity,6}|{GetQueueCapacity(queue),6}|{GetStackCapacity(stack),6}|{dictCap.buck,10}|{dictCap.entries,10}|");
			}
			Console.ReadLine();
		}

		static Func<Queue<T>, int> GetQueueCapacityFunc<T>()
		{
			Type queueType = typeof(Queue<T>);
			FieldInfo array = queueType.GetField("_array", BindingFlags.Instance | BindingFlags.NonPublic);
			return (Queue<T> q) => (array.GetValue(q) as T[]).Length;
		}

		static Func<Stack<T>, int> GetStackCapacityFunc<T>()
		{
			Type type = typeof(Stack<T>);
			FieldInfo array = type.GetField("_array", BindingFlags.Instance | BindingFlags.NonPublic);
			return (Stack<T> q) => (array.GetValue(q) as T[]).Length;
		}

		static Func<Dictionary<T, V>, (int buck, int entries)> GetDictionaryCapacityFunc<T, V>()
		{
			Type type = typeof(Dictionary<T, V>);
			FieldInfo buckets = type.GetField("buckets", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo entries = type.GetField("entries", BindingFlags.Instance | BindingFlags.NonPublic);
			return (Dictionary<T, V> q) => { return ((buckets.GetValue(q) as int[]).Length, (entries.GetValue(q) as Array).Length); };
		}
	}
}
