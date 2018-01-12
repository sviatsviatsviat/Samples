<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

	class Program
	{
		static void Main(string[] args)
		{
			var GetQueueCapacity = GetQueueCapacityFunc<int>();
			var GetStackCapacity = GetStackCapacityFunc<int>();
			var GetDictCapacity = GetDictionaryCapacityFunc<int,int>();

			List<int> list = new List<int>();
			Queue<int> queue = new Queue<int>();
			Stack<int> stack = new Stack<int>();
			Dictionary<int, int> dict = new Dictionary<int, int>();

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
		}

		static Func<Queue<T>,int> GetQueueCapacityFunc<T>()
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

		static Func<Dictionary<T,V>,(int buck,int entries)>GetDictionaryCapacityFunc<T,V>()
		{
			Type type = typeof(Dictionary<T,V>);
			FieldInfo buckets = type.GetField("buckets", BindingFlags.Instance | BindingFlags.NonPublic);
			FieldInfo entries = type.GetField("entries", BindingFlags.Instance | BindingFlags.NonPublic);
			return (Dictionary<T, V> q) => { return ((buckets.GetValue(q) as int[]).Length, (entries.GetValue(q) as Array).Length); };
		}
	}
