using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.Samples.Generic
{
	public class BinaryTreeNode<T> : IEnumerable<T>
	{
		private T _value;
		private BinaryTreeNode<T> _left, _right;

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

		public virtual void InsertChild(T value) //honestly, it could be better...
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
				_left.InsertChild(value);
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

		public IEnumerator<T> GetEnumerator() //try to return children's values too
		{
			if(_left != null)
			{
				yield return _left.Value;
			}
			yield return _value;
			if(_right != null)
			{
				yield return _right.Value;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class OrderableTreeNode<T> : BinaryTreeNode<T> where T : IComparable<T>
	{
		public OrderableTreeNode(T value) : base(value) { }

		public override void InsertChild(T value)
		{
			if (Value.CompareTo(value) > 0)
			{
				if (Left == null)
				{
					Left = new BinaryTreeNode<T>(value);
				}
				else
				{
					Left.InsertChild(value);
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
					Right.InsertChild(value);
				}
			}
		}

	}


	class Program
	{
		static void Main(string[] args)
		{
			IEnumerable<object> collection = null;

			BinaryTreeNode<object> objTree = new BinaryTreeNode<object>(1); //is it good?
			objTree.InsertChild(10);
			objTree.InsertChild("90");
			objTree.InsertChild(true);
			Console.WriteLine($"{nameof(objTree)} : {objTree}");
			collection = objTree;
			

			
			BinaryTreeNode<string> strTree = new BinaryTreeNode<string>("root");
			strTree.InsertChild("roof");
			strTree.InsertChild("proof");
			Console.WriteLine($"{nameof(strTree)} : {strTree}");
			collection = strTree; //why?

			//OrderableTreeNode<object> objOrdTree = new OrderableTreeNode<object>(5); - why?

			OrderableTreeNode<string> strOrderableTree = new OrderableTreeNode<string>("root");
			strOrderableTree.InsertChild("roof");
			strOrderableTree.InsertChild("proof");
			Console.WriteLine($"{nameof(strOrderableTree)} : {strOrderableTree}");
			collection = strOrderableTree; //why?

			Console.Read();
		}
	}
}
