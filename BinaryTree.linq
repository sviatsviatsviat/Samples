<Query Kind="Program" />

//the easiest way to implement IEnumerable
public class BinaryTreeNode<T> : IEnumerable<T>
{
		private T _value;
		private BinaryTreeNode<T> _left, _right, _parent = null;
		private bool _visited = false;

		public T Value
		{
			get
			{
				return _value;
			}
		}

		public BinaryTreeNode<T> Left
		{
			get
			{
				return _left;
			}
			protected set
			{
				_left = value;
			}
		}

		public BinaryTreeNode<T> Right
		{
			get
			{
				return _right;
			}
			protected set
			{
				_right = value;
			}
		}

		public BinaryTreeNode(T value)
		{
			_value = value;
		}
		
		public virtual void Add(T value)
		{
			if (_left == null)
			{
				_left = new BinaryTreeNode<T>(value);
			}
			else if (_right == null)
			{
				_right = new BinaryTreeNode<T>(value);
			}
			else
			{
				_left.Add(value);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			ToString(sb);
			return sb.ToString();
		}

		void ToString(StringBuilder context)
		{
			_left?.ToString(context);
			context.AppendFormat("{0}, ", _value);
			_right?.ToString(context);
		}
		
		/*A really bad implementation =(*/
		public IEnumerator<T> GetEnumerator()
		{
			var curr = this;
			while(curr != null)
			{
				if(curr._left != null && !curr._left._visited)
				{
					curr._left._parent = curr;
					curr = curr._left;
					continue;
				}
				
				if(!curr._visited)
				{
					yield return curr._value;
					curr._visited = true;
				}				
				
				if(curr._right != null && !curr._right._visited)
				{
					curr._right._parent = curr;
					curr = curr._right;
					continue;
				}
				
				if(curr._left != null) curr._left._visited = false;
				if(curr._right != null) curr._right._visited = false;
				curr = curr._parent;
			}
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class OrderableBinaryTreeNode<T> : BinaryTreeNode<T> where T : IComparable<T>
	{
		public OrderableBinaryTreeNode(T value) : base(value) { }

		public override void Add(T value)
		{
			if (Value.CompareTo(value) > 0)
			{
				if (Left == null)
				{
					Left = new BinaryTreeNode<T>(value);
				}
				else
				{
					Left.Add(value);
				}
			}
			else if (Value.CompareTo(value) < 0)
			{
				if (Right == null)
				{
					Right = new BinaryTreeNode<T>(value);
				}
				else
				{
					Right.Add(value);
				}
			}
		}

	}


	class Program
	{
		static void Main(string[] args)
		{
			BinaryTreeNode<int> strTree = new BinaryTreeNode<int>(5){3, 2, 1, 10, 17, 6};
			foreach(var item in strTree)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine(Environment.NewLine + "====================");
			OrderableBinaryTreeNode<int> strOrderableTree = new OrderableBinaryTreeNode<int>(5){3, 2, 1, 10, 17, 6};
			foreach(var item in strOrderableTree)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine(Environment.NewLine + "=============================");
			foreach(var item in strOrderableTree.Where(p => p > 7))
			{
				Console.Write($"{item} ");
			}
		}
	}